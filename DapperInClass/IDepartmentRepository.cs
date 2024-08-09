using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperInClass
{
    internal interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
    }
}
