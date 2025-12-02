using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.DTOs.DepartmentDTOs
{
    public class DepartmentDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateOnly LastUpdatedOn { get; set; }
    }
}
