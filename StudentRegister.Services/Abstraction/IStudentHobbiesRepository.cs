using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Abstraction
{
    public interface IStudentHobbiesRepository : IRepository<StudentHobbies>
    {
        void UpdateData(StudentHobbies entity);
        Task<List<StudentHobbies>> GetHobbiesByStudentId(int studentId);
    }
}
