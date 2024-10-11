using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.StudentHobbie.Queries;
using StudentRegister.Application.Students.Queries;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.StudentHobbie.QueryHandlers
{
    public class GetStudentHobbiesByStudentIdQueryHandler : IRequestHandler<GetStudentHobbiesByStudentId, List<StudentHobbies>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetStudentHobbiesByStudentIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<StudentHobbies>> Handle(GetStudentHobbiesByStudentId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StudentHobbiesRepository.GetHobbiesByStudentId(request.StudentId);
        }
    }
}
