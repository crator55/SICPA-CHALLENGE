using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SICPA.Classes;
using SICPA.Models;

namespace SICPA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly Employee employee = new();
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Employee/ListEmployees")]
        public IActionResult ListEmployee()
        {
            var list = employee.ListEmployee();
            return Ok(list);
        }

        [HttpGet]
        [Route("Employee/OneEmployee/{id}")]
        public IActionResult OneEmployee(int id)
        {
            var res = employee.OneEmployee(id);
            return Ok(res);
        }
        [HttpPost]
        [Route("Employee/SaveEmployee")]
        public IActionResult SaveEmployee([FromBody] EmployeeCLS EmployeeCLS)
        {
            bool res = false;
            try
            {
                res = employee.SaveEmployee(EmployeeCLS);
            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(res);
        }
        [HttpPut]
        [Route("Employee/EditEmployee/{id}")]
        public IActionResult EditEmployee([FromBody] EmployeeCLS EmployeeCLS, int id)
        {
            bool res = false;
            try
            {
                res = employee.EditEmployee(EmployeeCLS,id);
            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(res);
        }
        [HttpDelete]
        [Route("Employee/DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
           bool res = false;
            try
            {
                res = employee.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(res);
        }

    }

}
