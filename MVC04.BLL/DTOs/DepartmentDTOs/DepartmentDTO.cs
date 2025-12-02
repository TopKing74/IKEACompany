using MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.DTOs.DepartmentDTOs
{
    public class DepartmentDTO
    {       
        public int Id { get; set; }
        public string Name { get; set; } 
        public string? Description { get; set; } 

        public string Code { get; set; }
    }
}
