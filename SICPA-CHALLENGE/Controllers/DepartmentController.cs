using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SICPA.Classes;
using SICPA.Models;

namespace SICPA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly Department department = new();
        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Department/ListDepartment")]
        public IActionResult ListDepartment()
        {
            var res = department.GetDepartments();
            return Ok(res);
        }

        [HttpGet]
        [Route("Department/OneDepartment/{id}")]
        public IActionResult OneDepartment(int id)
        {
            var res = department.OneDepartment(id);
            return Ok(res);
        }
        [HttpPost]
        [Route("Department/SaveDepartment")]
        public IActionResult SaveDepartment([FromBody] DepartmentCLS departmentCLS)
        {
            bool res = false;
            try
            {
                res = department.SaveDepartment(departmentCLS);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(res);
        }
        [HttpPut]
        [Route("Department/EditDepartment/{id}")]
        public IActionResult EditDepartment([FromBody] DepartmentCLS departmentCLS, int id)
        {
            bool res = false;
            try
            {
                res = department.EditDepartment(departmentCLS, id);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(res);
        }
        [HttpDelete]
        [Route("Department/DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            bool res = false;
            try
            {
                res = department.DeleteDepartment(id);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(res);
        }
    }

}
