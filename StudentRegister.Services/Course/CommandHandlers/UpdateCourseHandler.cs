using AutoMapper;
using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Course.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Course.CommandHandlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourse, Courses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public UpdateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Courses> Handle(UpdateCourse request, CancellationToken cancellationToken)
        {
            var Course = _mapper.Map<Courses>(request);
            _unitOfWork.CoursesRepository.UpdateData(Course);
            await _unitOfWork.SaveChanges();
            return Course;
        }
    }
}
