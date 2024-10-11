using AutoMapper;
using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Students.CommandHandlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudent, StudentDetails>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentDetails> Handle(CreateStudent request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<StudentDetails>(request);
            _unitOfWork.StudentDetailsRepository.AddData(student);
             await _unitOfWork.SaveChanges();
            return student;
        }
    }
}
