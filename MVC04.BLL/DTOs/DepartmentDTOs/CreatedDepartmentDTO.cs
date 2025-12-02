using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC04.BLL.DTOs.DepartmentDTOs
{
    public class CreatedDepartmentDTO
    {
        [Required(ErrorMessage = "Name Is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code Is required")]
        public string Code { get; set; }
        public string? Description { get; set; }
    }
}
