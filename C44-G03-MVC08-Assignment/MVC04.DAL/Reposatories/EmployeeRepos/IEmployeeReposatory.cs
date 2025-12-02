using MVC04.DAL.Models.Employee;
using MVC04.DAL.Reposatories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Reposatories.EmployeeRepos
{
    public interface IEmployeeReposatory: IGenericReposatory<Employee>
    {
        public IEnumerable<Employee> GetAll(string SearchValue);
    }
}
