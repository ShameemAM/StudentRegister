using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Abstraction
{
    public interface ICoursesRepository : IRepository<Courses>
    {
        void UpdateData(Courses entity);
    }
}
