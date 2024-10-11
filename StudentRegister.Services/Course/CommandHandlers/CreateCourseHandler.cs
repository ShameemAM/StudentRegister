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
    public class CreateCourseHandler : IRequestHandler<CreateCourse, Courses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Courses> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            var Courses = _mapper.Map<Courses>(request);
            _unitOfWork.CoursesRepository.AddData(Courses);
            await _unitOfWork.SaveChanges();
            return Courses;
        }
    }
}
