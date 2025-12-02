using MVC04.DAL.Reposatories.DepartmentRepos;
using MVC04.DAL.Reposatories.EmployeeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.UOW
{
    public interface IUnitOfWork
    {
        public IEmployeeReposatory  employeeReposatory {  get; set; }
        public IDepartmentReposatory departmentReposatory { get; set; }

        public int Save();
    }
}
