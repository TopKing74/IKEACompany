using MVC04.DAL.Contexts;
using MVC04.DAL.Models.Department;
using MVC04.DAL.Models.Employee;
using MVC04.DAL.Reposatories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Reposatories.EmployeeRepos
{
    public class EmployeeReposatory : GenericReposatory<Employee>, IEmployeeReposatory
    {
        private readonly ApplicationDbContext _context;

        public EmployeeReposatory(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll(string SearchValue)
        {
            if (SearchValue is null)
            {
                return GetAll();
            }
            return _context.Employees.Where(e => e.Name.Trim().ToLower().Contains(SearchValue.Trim().ToLower()))
                                     .Where(e=>e.IsDeleted !=true);
        }
    }
}
