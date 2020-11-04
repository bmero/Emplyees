using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empleados.Model;
using EmpleadosData;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly EmployeesDbContext _context;

        public EmployeeController(EmployeesDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetEmployees()
        {
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();
            var data = await _context.GetEmployees();
            foreach (var item in data)
            {

                EmployeeViewModel employee = new EmployeeViewModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    SalaryAnual = EmployeeViewModel.calcsSalary(item)

                };

                list.Add(employee);
            }
            return list;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployee (int id)
        {
            var employee = await _context.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return new EmployeeViewModel
            {
                ID = employee.ID,
                Name = employee.Name,
                SalaryAnual = EmployeeViewModel.calcsSalary(employee)
            };
            
        }

    }
}
