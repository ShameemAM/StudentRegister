using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Course.Commands;
using StudentRegister.Application.Course.Queries;
using StudentRegister.Application.Hobbie.Queries;
using StudentRegister.Domain.Entities;

namespace StudentRegister.API.Controllers
{
    [Route("api/[Controller]")]
    public class CourseController : Controller
    {
        private IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCourseAsync()
        {
            var getAllCourses = new GetAllCourses();
            var Courses = await _mediator.Send(getAllCourses);
            return Ok(Courses);
        }
        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetCourseById(int Id)
        {
            var getCourse = new GetCourseById { Id = Id };
            var course = await _mediator.Send(getCourse);
            return Ok(course);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCourse([FromBody] Courses request)
        {
            var createCourse = new CreateCourse
            {
                CourseName = request.CourseName
            };
            var courses = await _mediator.Send(createCourse);
            return Created();
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCourse([FromBody] Courses request)
        {
            var updateCourse = new UpdateCourse
            {
                Id= request.Id,
                CourseName = request.CourseName
            };
            var courses = await _mediator.Send(updateCourse);
            return Ok(courses);
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCourse(int Id)
        {
            var deleteCourse = new DeleteCourse
            {
                Id = Id
            };
            await _mediator.Send(deleteCourse);
            return NoContent();
        }
    }
}
