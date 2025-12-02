using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC04.BLL.DTOs.DepartmentDTOs;
using MVC04.BLL.DTOs.EmployeeDTOs;
using MVC04.BLL.Services.DepartmentServ;
using MVC04.BLL.Services.EmployeeServ;
using MVC04.DAL.Models.Department;
using MVC04.PL.ViewModels.EmployeeVMs;

namespace MVC04.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment webHost;

        public EmployeeController(IEmployeeServices employeeServices, ILogger<EmployeeController> logger, IWebHostEnvironment webHost)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.webHost = webHost;
        }
        public IActionResult Index(string? SearchValue)
        {
            if (SearchValue == null)
            {
                return View(employeeServices.GetAllEmployee());
            }
            else
            {
                return View(employeeServices.GetSearchedEmployee(SearchValue));
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new EmployeeVM());
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                var dto = new CreatedEmployeeDto
                {
                    Name = vm.Name,
                    Age = vm.Age,
                    Address = vm.Address,
                    Email = vm.Email,
                    PhoneNumber = vm.PhoneNumber,
                    Salary = vm.Salary,
                    IsActive = vm.IsActive,
                    EmployeeType = vm.EmployeeType,
                    Gender = vm.Gender,
                    DepartmentId = vm.DepartmentId,
                    Image= vm.Image
                };

                int res = employeeServices.AddEmployee(dto);
                if (res > 0)
                {
                    TempData["Message"] = $"Employee {vm.Name} Added Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = $"Department {vm.Name} Cannot be Created!";
                    return View(vm);
                }
            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(vm);
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dept = employeeServices.GetEmployeeById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var emp = employeeServices.GetEmployeeById(id);
            if (emp == null) return NotFound();

            var vm = new EmployeeVM
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Address = emp.Address,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                HiringDate = emp.HiringDate,
                Salary = emp.Salary,
                IsActive = emp.IsActive,
                DepartmentId= emp.DepartmentId,
                ImageName= emp.ImageName
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var dto = new UpdatedEmployeeDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                Age = vm.Age,
                Address = vm.Address,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                HiringDate = vm.HiringDate,
                Salary = vm.Salary,
                IsActive = vm.IsActive,
                EmployeeType = vm.EmployeeType,
                Gender = vm.Gender,
                DepartmentId = vm.DepartmentId,
                Image= vm.Image
            };

            employeeServices.UpdateEmployee(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dept = employeeServices.GetEmployeeById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeDTO dto)
        {
            try
            {
                int res = employeeServices.DeleteEmployee(dto.Id);
                if (res > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't be Deleted");
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(dto);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
