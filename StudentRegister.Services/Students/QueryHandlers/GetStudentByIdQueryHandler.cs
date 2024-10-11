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
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentById, StudentDetails>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetStudentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentDetails> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StudentDetailsRepository.GetSingleValue(s=>s.Id==request.Id);
        }
    }
}
