using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Hobbie.Commands;
using StudentRegister.Application.StudentHobbie.Commands;

namespace StudentRegister.API.Controllers
{
    [Route("api/[Controller]")]
    public class StudentHobbiesController : Controller
    {
        private IMediator _mediator;
        public StudentHobbiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteHobbie(int Id)
        {
            var deleteHobbie = new DeleteStudentHobbie
            {
                Id = Id
            };
            await _mediator.Send(deleteHobbie);
            return NoContent();
        }
    }
}
