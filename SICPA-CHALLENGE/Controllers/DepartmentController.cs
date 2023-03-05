using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Department/ListDepartment")]
        public IActionResult ListDepartment()
        {
            List<DepartmentCLS> list = new();
            using SicpaContext bd = new();
            list = (from DepartmentCLS in bd.Departments
                    join Enterp in bd.Enterprises
                    on DepartmentCLS.IdEnterprise equals Enterp.Id
                    select new DepartmentCLS()
                    {
                        Id= DepartmentCLS.Id,
                        Status = DepartmentCLS.Status.ToString(),
                        Description=DepartmentCLS.Description,
                        Name= DepartmentCLS.Name,
                        Phone= DepartmentCLS.Phone,
                        EnterpriseName= Enterp.Name
                    }).ToList();
            return Ok(list);
        }
        
        [HttpGet]
        [Route("Department/OneDepartment/{id}")]
        public IActionResult OneDepartment(int id)
        {
            DepartmentCLS department = new();
            using SicpaContext bd = new();
            department = (
                    from DepartmentCLS in bd.Departments
                    join Enterp in bd.Enterprises
                    on DepartmentCLS.IdEnterprise equals Enterp.Id
                    where DepartmentCLS.Id == id
                    select new DepartmentCLS()
                    {
                        Id = DepartmentCLS.Id,
                        Status = DepartmentCLS.Status.ToString(),
                        Description = DepartmentCLS.Description,
                        Name = DepartmentCLS.Name,
                        Phone = DepartmentCLS.Phone,
                        EnterpriseName= Enterp.Name
                    }).First();
            return Ok(department);
        }
        [HttpPost]
        [Route("Department/SaveDepartment")]
        public IActionResult SaveDepartment([FromBody]DepartmentCLS departmentCLS)
        {
           
            try
            {
                using SicpaContext bd = new();
                Department odepartment = new()
                {
                    Status = bool.Parse(departmentCLS.Status),
                    Description = departmentCLS.Description,
                    Name = departmentCLS.Name,
                    Phone = departmentCLS.Phone,
                    IdEnterprise = int.Parse(departmentCLS.EnterpriseName),
                    CreatedDate= DateTime.Now,
                };
                bd.Add(odepartment);
                bd.SaveChanges();

            }
            catch (Exception ex)
            {

             Problem(ex.Message);
            }
            return Ok(departmentCLS);
        }
        [HttpPut]
        [Route("Department/EditDepartment/{id}")]
        public IActionResult EditDepartment([FromBody] DepartmentCLS departmentCLS,int id)
        {
            int res = 1;
            try
            {
                using SicpaContext bd = new();
                Department odepartment = new()
                {
                    Id= id
                };
                bd.Attach(odepartment);
                odepartment.Status = bool.Parse(departmentCLS.Status);
                odepartment.Description = departmentCLS.Description;
                odepartment.Name = departmentCLS.Name;
                odepartment.Phone = departmentCLS.Phone;
                odepartment.IdEnterprise = int.Parse(departmentCLS.EnterpriseName);
                odepartment.ModifiedDate = DateTime.Now;
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(departmentCLS);
        }
        [HttpDelete]
        [Route("Department/DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment( int id)
        {
            int res = 1;
            try
            {
                using SicpaContext bd = new();
                Department odepartment = new()
                {
                    Id = id,
                    IdEnterprise = 1
                };
                bd.Attach(odepartment);
                bd.Departments.Attach(odepartment);
                bd.Departments.Remove(odepartment);
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(res);
        }
    }
    
}
