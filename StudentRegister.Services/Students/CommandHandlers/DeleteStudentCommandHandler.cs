using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Students.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Students.CommandHandlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudent>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentDetailsRepository.GetSingleValue(s=>s.Id==request.Id);
            if (student == null) return;
            _unitOfWork.StudentDetailsRepository.RemoveData(student);
            await _unitOfWork.SaveChanges();
        }
    }
}
