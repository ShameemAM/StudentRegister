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
    public class GetAllCousesQueryHandler : IRequestHandler<GetAllCourses, List<Courses>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCousesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Courses>> Handle(GetAllCourses request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CoursesRepository.GetAll();
        }
    }
}
