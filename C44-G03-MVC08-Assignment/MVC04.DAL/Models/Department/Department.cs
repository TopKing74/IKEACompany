using MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Models.Department
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee.Employee> Employees { get; set; }= new HashSet<Employee.Employee>();    
    }
}
