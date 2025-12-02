using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC04.BLL.DTOs.DepartmentDTOs;
using MVC04.BLL.Services.DepartmentServ;
using MVC04.PL.ViewModels.DepartmentVMs;

namespace MVC04.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices department;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment webHost;

        public DepartmentController(IDepartmentServices department, ILogger<DepartmentController> logger, IWebHostEnvironment webHost)
        {
            this.department = department;
            this.logger = logger;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            var data = department.GetAllDepartment();
            return View(data);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(DepartmentVM ViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = new CreatedDepartmentDTO
                    {
                        Name = ViewModel.Name,
                        Code = ViewModel.Code,
                        Description = ViewModel.Description
                    };
                    int res = department.AddDepartment(dto);
                    if (res > 0)
                    {
                        TempData["Message"] = $"Department {ViewModel.Name} Created Successfully!";
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["Message"] = $"Department {ViewModel.Name} Cannot be Created!";
                        return View(ViewModel);
                    }
                }
                else
                {
                    return View(ViewModel);
                }

            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(ViewModel);
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
            var dept = department.GetDepartmentById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dept = department.GetDepartmentById(id);
            if (dept == null)
            {
                return NotFound();
            }
            var DeptVM = new DepartmentVM
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                Description = dept.Description
            };
            return View(DeptVM);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = new UpdatedDepartmentDTO
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        Code = vm.Code,
                        Description = vm.Description
                    };
                    int res = department.UpdateDepartment(dto);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't be Updated");
                        return View(vm);
                    }
                }
                else
                {
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
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dept = department.GetDepartmentById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentDTO dto)
        {
            try
            {
                int res = department.DeleteDepartment(dto.Id);
                if (res > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can't be Deleted");
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
