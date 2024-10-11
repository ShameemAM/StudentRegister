using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentRegister.Application.Abstraction;
using StudentRegister.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StudentRegister.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public AccountController(IUnitOfWork unitOfWork, IConfiguration config)
        { 
            _unitOfWork = unitOfWork;
            _config = config;
        }
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] Users user)
        {
            if (user == null)
            {
                return NotFound("user not found");
            }
            string password = HashPasword(user.Password, out byte[] salt);
            user.Salt = Convert.ToHexString(salt);
            user.Password = password;
            _unitOfWork.UsersRepository.AddUser(user);
            await _unitOfWork.SaveChanges();
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] Users userLogin)
        {
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                return Ok(new {token = tokenString});
            }

            return NotFound("user not found");
        }

        string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        private string GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",user.Email)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private async Task<Users> Authenticate(Users userLogin)
        {
            var currentUser = await _unitOfWork.UsersRepository.GetUsers(userLogin.Email);
            if (currentUser != null)
            {
                bool isPasswordVerified = VerifyPassword(userLogin.Password, currentUser.Password, Convert.FromHexString(currentUser.Salt));
                if (isPasswordVerified)
                    return currentUser;
            }
            return null;
        }
        bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
