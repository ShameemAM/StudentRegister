using AutoMapper;
using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.StudentHobbie.CommandHandlers
{
    public class CreateStudentHobbieCommandHandler : IRequestHandler<CreateStudentHobbie, StudentHobbies>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateStudentHobbieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentHobbies> Handle(CreateStudentHobbie request, CancellationToken cancellationToken)
        {
            var studentHobbie = _mapper.Map<StudentHobbies>(request);
            _unitOfWork.StudentHobbiesRepository.AddData(studentHobbie);
            await _unitOfWork.SaveChanges();
            return studentHobbie;
        }
    }
}
