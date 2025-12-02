using MVC04.BLL.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Services.DepartmentServ
{
    public interface IDepartmentServices
    {
        public IEnumerable<DepartmentDTO> GetAllDepartment();
        public DepartmentDetailsDTO GetDepartmentById(int id);
        public int AddDepartment(CreatedDepartmentDTO dto);
        public int UpdateDepartment(UpdatedDepartmentDTO dto);
        public int DeleteDepartment(int id);
    }
}
