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
    public class GetAllHobbiesQueryHandler : IRequestHandler<GetAllHobbies, List<Hobbies>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllHobbiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Hobbies>> Handle(GetAllHobbies request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.HobbiesRepository.GetAll();
        }
    }
}
