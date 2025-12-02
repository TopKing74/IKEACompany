using MVC04.BLL.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Services.EmployeeServ
{
    public interface IEmployeeServices
    {
        public IEnumerable<EmployeeDTO> GetAllEmployee();
        public EmployeeDetailsDTO GetEmployeeById(int id);
        public int AddEmployee(CreatedEmployeeDto dto);
        public int UpdateEmployee(UpdatedEmployeeDTO dto);
        public int DeleteEmployee(int? id);
        public IEnumerable<EmployeeDTO> GetSearchedEmployee(string? SearchValue);
    }
}
