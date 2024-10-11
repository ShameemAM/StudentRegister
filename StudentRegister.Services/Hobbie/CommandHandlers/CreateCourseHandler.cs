using AutoMapper;
using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Hobbie.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Hobbie.CommandHandlers
{
    public class CreateHobbieHandler : IRequestHandler<CreateHobbie, Hobbies>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateHobbieHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Hobbies> Handle(CreateHobbie request, CancellationToken cancellationToken)
        {
            var hobbies = _mapper.Map<Hobbies>(request);
            _unitOfWork.HobbiesRepository.AddData(hobbies);
            await _unitOfWork.SaveChanges();
            return hobbies;
        }
    }
}
