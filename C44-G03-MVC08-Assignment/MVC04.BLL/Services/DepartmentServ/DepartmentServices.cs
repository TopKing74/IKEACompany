using MVC04.BLL.DTOs.DepartmentDTOs;
using MVC04.BLL.Factories.DepartmentFactories;
using MVC04.DAL.Reposatories.DepartmentRepos;
using MVC04.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.BLL.Services.DepartmentServ
{
    public class DepartmentServices: IDepartmentServices
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentDTO> GetAllDepartment()
        {
            var Department = unitOfWork.departmentReposatory.GetAll();

            List<DepartmentDTO> MappedDepartment = new List<DepartmentDTO>();
            foreach (var d in Department)
            {
                var MappedDTO = d.ToDepartmnetDTO();
                MappedDepartment.Add(MappedDTO);
            }

            return MappedDepartment;
        }

        public DepartmentDetailsDTO GetDepartmentById(int id)
        {
            var d = unitOfWork.departmentReposatory.GetById(id);
            if (d == null) return null;
            var MappedDepartment = d.ToEntity();
            return MappedDepartment;
        }

        public int AddDepartment (CreatedDepartmentDTO dto)
        {
            var department = dto.ToDepartment();
            unitOfWork.departmentReposatory.Add(department);
            return unitOfWork.Save();

        }

        public int UpdateDepartment (UpdatedDepartmentDTO dto )
        {
             var department = dto.FromUpdateDepartment();
            unitOfWork.departmentReposatory.Update(department);
            return unitOfWork.Save();
        }

        public int DeleteDepartment (int id)
        {
            unitOfWork.departmentReposatory.Delete(id);
            return unitOfWork.Save();
        }


    }
}
