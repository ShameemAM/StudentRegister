using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Students.Queries;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Students.QueryHandlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudents, List<StudentDetails>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllStudentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudentDetails>> Handle(GetAllStudents request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StudentDetailsRepository.GetAll();
        }
    }
}
