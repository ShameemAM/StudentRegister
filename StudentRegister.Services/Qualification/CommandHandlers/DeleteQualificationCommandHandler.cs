using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Qualifications.Commands;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Qualifications.CommandHandlers
{
    public class DeleteQualificationCommandHandler : IRequestHandler<DeleteQualification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteQualificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteQualification request, CancellationToken cancellationToken)
        {
            var qualification = await _unitOfWork.QualificationRepository.GetSingleValue(s => s.Id == request.Id);
            if (qualification == null) return;
            _unitOfWork.QualificationRepository.RemoveData(qualification);
            await _unitOfWork.SaveChanges();
        }
    }
}
