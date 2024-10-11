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
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudent, StudentDetails>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentDetails> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<StudentDetails>( request );
            _unitOfWork.StudentDetailsRepository.UpdateData( student );
            await _unitOfWork.SaveChanges();
            return student;
        }
    }
}
