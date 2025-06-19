using EmployeeAdminPortal.UI.ClientModels;
using EmployeeAdminPortal.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.UI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var emp = await _service.GetByIdAsync(id);
            if (emp == null) return NotFound();

            var dto = new UpdateEmployeeDto
            {
                Name = emp.Name,
                Email = emp.Email,
                Phone = emp.Phone,
                Salary = emp.Salary
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UpdateEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
