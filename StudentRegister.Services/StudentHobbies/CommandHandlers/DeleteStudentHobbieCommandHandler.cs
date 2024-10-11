using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.StudentHobbie.CommandHandlers
{
    public class DeleteStudentHobbieCommandHandler : IRequestHandler<DeleteStudentHobbie>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStudentHobbieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteStudentHobbie request, CancellationToken cancellationToken)
        {
            var studentHobbie = await _unitOfWork.StudentHobbiesRepository.GetSingleValue(s => s.Id == request.Id);
            if (studentHobbie == null) return;
            _unitOfWork.StudentHobbiesRepository.RemoveData(studentHobbie);
            await _unitOfWork.SaveChanges();
        }
    }
}
