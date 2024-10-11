using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Hobbie.Queries;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Hobbie.QueryHandles
{
    public class GetHobbieByIdQueryHandler : IRequestHandler<GetHobbieById,Hobbies>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetHobbieByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Hobbies> Handle(GetHobbieById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.HobbiesRepository.GetSingleValue(h=>h.Id == request.Id);
        }
    }
}
