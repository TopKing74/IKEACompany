 using AutoMapper;
using MVC04.BLL.DTOs.EmployeeDTOs;
using MVC04.DAL.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Common.MappingProfiles
{
    public class ProjectMapperProfile:Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ForMember (d=> d.DepartmentName, opt=> opt.MapFrom 
            (s=> s.Department.Name!= null ? s.Department.Name: "N/A")).ReverseMap();

            CreateMap<Employee, EmployeeDetailsDTO>().ForMember(d => d.DepartmentName, opt => opt.MapFrom
            (s => s.Department.Name != null ? s.Department.Name : "N/A")).ReverseMap();

            CreateMap<CreatedEmployeeDto, Employee>().ReverseMap();

            CreateMap<UpdatedEmployeeDTO, Employee>().ReverseMap();
        }

    }
}
