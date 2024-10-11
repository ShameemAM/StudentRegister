using MediatR;
using StudentRegister.Application.Abstraction;
using StudentRegister.Application.Course.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Course.CommandHandlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCourseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteCourse request, CancellationToken cancellationToken)
        {
            var Course = await _unitOfWork.CoursesRepository.GetSingleValue(c=>c.Id == request.Id);
            if (Course == null) return;
            _unitOfWork.CoursesRepository.RemoveData(Course);
            await _unitOfWork.SaveChanges();
        }
    }
}
