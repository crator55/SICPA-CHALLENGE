using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SICPA.Classes;
using SICPA.Models;
using SICPA_CHALLENGE.Controllers;

namespace SICPA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Employee/ListEmployees")]
        public IActionResult ListEmployee()
        {
            List<EmployeeCLS> list = new();
            using SicpaContext bd = new();
            list = (from EmployeeCLS in bd.Employees
                    select new EmployeeCLS()
                    {
                        Id = EmployeeCLS.Id,
                        Status = EmployeeCLS.Status.ToString(),
                        Age = EmployeeCLS.Age,
                        Email = EmployeeCLS.Email,
                        Name = EmployeeCLS.Name,
                        Position = EmployeeCLS.Position,
                        Surname = EmployeeCLS.Surname,
                    }).ToList();
            return Ok(list);
        }

        [HttpGet]
        [Route("Employee/OneEmployee/{id}")]
        public IActionResult OneEmployee(int id)
        {
            EmployeeCLS Employee = new();
            using SicpaContext bd = new();
            Employee = (
                    from EmployeeCLS in bd.Employees
                    where EmployeeCLS.Id == id
                    select new EmployeeCLS()
                    {
                        Id = EmployeeCLS.Id,
                        Status = EmployeeCLS.Status.ToString(),
                        Age = EmployeeCLS.Age,
                        Email = EmployeeCLS.Email,
                        Name = EmployeeCLS.Name,
                        Position = EmployeeCLS.Position,
                        Surname = EmployeeCLS.Surname
                    }).First();
            return Ok(Employee);
        }
        [HttpPost]
        [Route("Employee/SaveEmployee")]
        public IActionResult SaveEmployee([FromBody] EmployeeCLS EmployeeCLS)
        {
          
            try
            {
                using SicpaContext bd = new();
                Employee oEmployee = new()
                {
                    Status = bool.Parse(EmployeeCLS.Status),
                    Age = EmployeeCLS.Age,
                    Email = EmployeeCLS.Email,
                    Name = EmployeeCLS.Name,
                    Position = EmployeeCLS.Position,
                    Surname = EmployeeCLS.Surname,
                    CreatedDate= DateTime.Now
                };
                bd.Add(oEmployee);
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Conflict(ex); 
            }
            return Ok(EmployeeCLS);
        }
        [HttpPut]
        [Route("Employee/EditEmployee/{id}")]
        public IActionResult EditEmployee([FromBody] EmployeeCLS EmployeeCLS, int id)
        {
            try
            {
                using SicpaContext bd = new();
                Employee oEmployee = new()
                {
                    Id = id
                };
                bd.Attach(oEmployee);
                oEmployee.Status = bool.Parse(EmployeeCLS.Status);
                oEmployee.Age = EmployeeCLS.Age;
                oEmployee.Email = EmployeeCLS.Email;
                oEmployee.Name = EmployeeCLS.Name;
                oEmployee.Position = EmployeeCLS.Name;
                oEmployee.Surname = EmployeeCLS.Surname;
                oEmployee.ModifiedDate = DateTime.Now;
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(EmployeeCLS);
        }
        [HttpDelete]
        [Route("Employee/DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            int res = 1;
            try
            {
                using SicpaContext bd = new();
                Employee oEmployee = new()
                {
                    Id = id
                };
                bd.Attach(oEmployee);
                bd.Employees.Attach(oEmployee);
                bd.Employees.Remove(oEmployee);
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(res);
        }

    }

}
