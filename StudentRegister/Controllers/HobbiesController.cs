using Microsoft.AspNetCore.Mvc;

namespace StudentRegister.API.Controllers
{
    public class HobbiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
