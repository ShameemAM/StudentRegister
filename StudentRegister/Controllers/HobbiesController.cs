using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Hobbie.Commands;
using StudentRegister.Application.Hobbie.Queries;
using StudentRegister.Domain.Entities;

namespace StudentRegister.API.Controllers
{
    [Route("api/[Controller]")]
    public class HobbiesController : Controller
    {
        private readonly IMediator _mediator;
        public HobbiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllHobbies()
        {
            var getAllHobbies = new GetAllHobbies();
            var hobbies = await _mediator.Send(getAllHobbies);
            return Ok(hobbies);
        }
        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetHobbieById(int Id)
        {
            var getHobbie = new GetHobbieById{Id = Id };
            var hobbie = await _mediator.Send(getHobbie);
            return Ok(hobbie);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateHobbie([FromBody] Hobbies request)
        {
            var createHobbie = new CreateHobbie
            {
                Hobbie = request.Hobbie
            };
            var hobbie = await _mediator.Send(createHobbie);
            return Created();
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateHobbi([FromBody] Hobbies request)
        {
            var updateHobbie = new UpdateHobbie
            {
                Id = request.Id,
                Hobbie = request.Hobbie
            };
            var hobbie = await _mediator.Send(updateHobbie);
            return Ok(hobbie);
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteHobbie(int Id)
        {
            var deleteHobbie = new DeleteHobbie
            {
                Id = Id
            };
            await _mediator.Send(deleteHobbie);
            return NoContent() ;
        }
    }
}
