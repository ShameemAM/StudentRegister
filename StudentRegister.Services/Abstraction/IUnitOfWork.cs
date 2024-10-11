using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Abstraction
{
    public interface IUnitOfWork
    {
        ICoursesRepository CoursesRepository { get; }
        IHobbiesRepository HobbiesRepository { get; }
        IQualificationRepository QualificationRepository { get; }
        IStudentDetailsRepository StudentDetailsRepository { get; }
        IStudentHobbiesRepository StudentHobbiesRepository { get; }
        IUsersRepository UsersRepository { get; }
        Task SaveChanges();
    }
}
