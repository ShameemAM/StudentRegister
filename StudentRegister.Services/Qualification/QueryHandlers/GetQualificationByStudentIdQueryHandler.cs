using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Qualifications.Queries;
using StudentRegister.Application.Students.Queries;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Qualifications.QueryHandlers
{
    public class GetQualificationByStudentIdQueryHandler : IRequestHandler<GetQualificationByStudentId, Qualification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetQualificationByStudentIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Qualification> Handle(GetQualificationByStudentId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.QualificationRepository.GetSingleValue(q => q.StudentId == request.StudentId);
        }
    }
}
