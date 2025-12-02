using MVC04.DAL.Contexts;
using MVC04.DAL.Models.Department;
using MVC04.DAL.Reposatories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Reposatories.DepartmentRepos
{
    public class DepartmentReposatory : GenericReposatory<Department>, IDepartmentReposatory
    {
        private readonly ApplicationDbContext _context;
        public DepartmentReposatory(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

    }
}
