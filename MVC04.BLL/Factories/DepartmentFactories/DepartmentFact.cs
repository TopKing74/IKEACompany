using MVC04.BLL.DTOs.DepartmentDTOs;
using MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Factories.DepartmentFactories
{
    public static class DepartmentFact
    {
        public static DepartmentDTO  ToDepartmnetDTO (this Department department)
        {
            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description
            };
        }
        public static DepartmentDetailsDTO ToEntity (this Department department)
        {
            return new DepartmentDetailsDTO
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                CreatedBy = department.CreatedBy,
                LastUpdatedBy = department.LastUpdatedBy,
                LastUpdatedOn = DateOnly.FromDateTime(department.LastUpdatedOn)
            };
        }

        public static Department ToDepartment (this CreatedDepartmentDTO dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now,
                IsDeleted = false
            };
        }

        public static Department FromUpdateDepartment(this UpdatedDepartmentDTO dto)
        {
            return new Department()
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now,
                IsDeleted = false
            };
        }
    }
}
