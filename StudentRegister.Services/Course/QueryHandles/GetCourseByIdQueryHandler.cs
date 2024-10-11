using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Course.Queries;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Course.QueryHandles
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseById, Courses>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Courses> Handle(GetCourseById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CoursesRepository.GetSingleValue(c=>c.Id==request.Id);
        }
    }
}
