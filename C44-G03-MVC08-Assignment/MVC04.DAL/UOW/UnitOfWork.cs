using MVC04.DAL.Contexts;
using MVC04.DAL.Reposatories.DepartmentRepos;
using MVC04.DAL.Reposatories.EmployeeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public IEmployeeReposatory employeeReposatory { get; set; }
        public IDepartmentReposatory departmentReposatory { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            employeeReposatory= new EmployeeReposatory(context);
            departmentReposatory = new DepartmentReposatory(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
