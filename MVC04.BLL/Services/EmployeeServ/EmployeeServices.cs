using AutoMapper;
using MVC04.BLL.Common.Services.Attachment;
using MVC04.BLL.DTOs.EmployeeDTOs;
using MVC04.DAL.Models.Employee;
using MVC04.DAL.Reposatories.EmployeeRepos;
using MVC04.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Services.EmployeeServ
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAttachmentServices attachmentServices;

        public EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper, IAttachmentServices attachmentServices)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.attachmentServices = attachmentServices;
        }
        public int AddEmployee(CreatedEmployeeDto dto)
        {
            var employee= mapper.Map<CreatedEmployeeDto,Employee>(dto);
            if (dto.Image is not  null )
            {
                employee.ImageName= attachmentServices.UploadImg(dto.Image, "imgs");
            }
            employee.CreatedBy = 1;
            employee.CreatedOn = DateTime.Now;
            employee.LastUpdatedBy = 1;
            employee.LastUpdatedOn = DateTime.Now;

            unitOfWork.employeeReposatory.Add(employee);
            return unitOfWork.Save();
        }

        public int DeleteEmployee(int? id)
        {
            var  employee= unitOfWork.employeeReposatory.GetById(id);
            if (employee is not null)
            {
                if(employee.ImageName is not null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "imgs", employee.ImageName);
                    attachmentServices.DeleteImg(path);
                }
                unitOfWork.employeeReposatory.Delete(employee.Id);
                return unitOfWork.Save();
            }
            else return 0;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployee()=>
             mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(unitOfWork.employeeReposatory.GetAll().ToList());


        public EmployeeDetailsDTO GetEmployeeById(int id)=>
             mapper.Map<Employee, EmployeeDetailsDTO>(unitOfWork.employeeReposatory.GetById(id));

        public IEnumerable<EmployeeDTO> GetSearchedEmployee(string? SearchValue)=>
             mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(unitOfWork.employeeReposatory.GetAll(SearchValue).ToList());

        public int UpdateEmployee(UpdatedEmployeeDTO dto)
        {
            
            var employee = mapper.Map<UpdatedEmployeeDTO, Employee>(dto);
            if (dto.Image is not null)
            {
                if (employee.ImageName is not null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "imgs", employee.ImageName);
                    attachmentServices.DeleteImg(path);
                }
                employee.ImageName = attachmentServices.UploadImg(dto.Image, "imgs");
            }
            employee.LastUpdatedBy = 1;
            employee.LastUpdatedOn = DateTime.Now;
            unitOfWork.employeeReposatory.Update(employee);
            return unitOfWork.Save();

        }

    }
}
