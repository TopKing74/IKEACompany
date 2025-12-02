using System.ComponentModel.DataAnnotations;

namespace MVC04.PL.ViewModels.DepartmentVMs
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        public string? Description { get; set; }
    }
}
