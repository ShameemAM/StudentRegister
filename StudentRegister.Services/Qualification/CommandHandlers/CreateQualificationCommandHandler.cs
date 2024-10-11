using AutoMapper;
using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Qualifications.Commands;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Qualifications.CommandHandlers
{
    public class CreateQualificationCommandHandler : IRequestHandler<CreateQualification, Qualification>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateQualificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Qualification> Handle(CreateQualification request, CancellationToken cancellationToken)
        {
            var qualification = _mapper.Map<Qualification>(request);
            _unitOfWork.QualificationRepository.AddData(qualification);
            await _unitOfWork.SaveChanges();
            return qualification;
        }
    }
}
