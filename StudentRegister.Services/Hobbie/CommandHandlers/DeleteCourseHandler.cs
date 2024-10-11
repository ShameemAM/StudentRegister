using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Hobbie.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Hobbie.CommandHandlers
{
    public class DeleteHobbieHandler : IRequestHandler<DeleteHobbie>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteHobbieHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteHobbie request, CancellationToken cancellationToken)
        {
            var hobbie = await _unitOfWork.HobbiesRepository.GetSingleValue(c=>c.Id == request.Id);
            if (hobbie == null) return;
            _unitOfWork.HobbiesRepository.RemoveData(hobbie);
            await _unitOfWork.SaveChanges();
        }
    }
}
