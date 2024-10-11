using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.API.Models;
using StudentRegister.Application.Course.Queries;
using StudentRegister.Application.Hobbie.Commands;
using StudentRegister.Application.Hobbie.Queries;
using StudentRegister.Application.Qualifications.Commands;
using StudentRegister.Application.Qualifications.Queries;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.StudentHobbie.Queries;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Application.Students.Queries;
using StudentRegister.Domain.Entities;

namespace StudentRegister.API.Controllers
{
    [Route("api/[Controller]")]
    public class StudentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public StudentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStudents()
        {
                var getAllStudents = new GetAllStudents();
                var students = await _mediator.Send(getAllStudents);
                return Ok(students);
        }
        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            try
            {
                var studentDetailsRespose = new GetStudentByIdResponseModel();
                var getStudent = new GetStudentById { Id = Id };
                studentDetailsRespose.StudentModel = await _mediator.Send(getStudent);
                if (studentDetailsRespose.StudentModel == null) return NotFound();
                var getQualificationDetails = new GetQualificationByStudentId { StudentId = Id };
                studentDetailsRespose.QualificationModel = await _mediator.Send(getQualificationDetails);
                var getCourse = new GetCourseById { Id = studentDetailsRespose.StudentModel.CourseId };
                studentDetailsRespose.CourseModel = await _mediator.Send(getCourse);
                var getHobbies = new GetStudentHobbiesByStudentId { StudentId = Id };
                studentDetailsRespose.StudentHobbiesModel = await _mediator.Send(getHobbies);

                return Ok(studentDetailsRespose);
            }
            catch (Exception ex) 
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStudents([FromBody] StudentRegisterModel request)
        {
            try
            {
                var createStudent = new CreateStudent();
                createStudent=request.StudentModel;
                var student = await _mediator.Send(createStudent);
                if (student != null)
                {
                    request.QualificationModel.StudentId = student.Id;
                    request.StudentHobbiesModel.ForEach(sh => sh.StudentId = student.Id);
                    var qualification = new CreateQualification();
                    qualification = request.QualificationModel;
                    var qualifications = await _mediator.Send(qualification);
                    foreach (var item in request.StudentHobbiesModel)
                    {
                        var studentHobbie = new CreateStudentHobbie();
                        studentHobbie = item;
                        var hobbie = await _mediator.Send(studentHobbie);
                    }
                }
                return Created();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentUpdateModel request)
        {
            try
            {
                var updateStudent = new UpdateStudent();
                updateStudent = request.StudentModel;
                var student = await _mediator.Send(updateStudent);
                if (student == null) return NotFound();
                var qualification = new UpdateQualification();
                qualification = request.QualificationModel;
                
                var qualifications = await _mediator.Send(qualification);
                foreach (var item in request.StudentHobbiesModel)
                {
                    if (item.Id <= 0)
                    {
                        var createStudentHobbie = new CreateStudentHobbie
                        {
                            StudentId = student.Id,
                            Hobbie = item.Hobbie
                        };
                        var CreatedHobbie = await _mediator.Send(createStudentHobbie);
                    }
                    else
                    {
                        var studentHobbie = new UpdateStudentHobbie();
                        studentHobbie = item;
                        var hobbie = await _mediator.Send(studentHobbie);
                    }
                }
                return Ok(request);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            try
            {
                var deleteStudent = new DeleteStudent { Id = Id };
                await _mediator.Send(deleteStudent);

               
                return NoContent() ;
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
