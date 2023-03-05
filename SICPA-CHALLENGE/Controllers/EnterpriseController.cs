using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SICPA.Classes;
using SICPA.Models;

namespace SICPA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class EnterpriseController : ControllerBase
    {
        private readonly ILogger<EnterpriseController> _logger;

        public EnterpriseController(ILogger<EnterpriseController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Enterprise/ListEnterprise")]
        public IEnumerable<EnterpriseCLS> ListEnterprise()
        {
            List<EnterpriseCLS> list = new();
            using SicpaContext bd = new();
            list = (from EnterprisesCLS in bd.Enterprises
                    select new EnterpriseCLS()
                    {
                        Id= EnterprisesCLS.Id,
                        Status = EnterprisesCLS.Status.ToString(),
                        Address = EnterprisesCLS.Address,
                        Name= EnterprisesCLS.Name,
                        Phone= EnterprisesCLS.Phone
                    }).ToList();
            return list;
        }
        [HttpGet]
        [Route("Enterprise/OneEnterprise/{id}")]
        public IActionResult OneEnterprise(int id)
        {
            EnterpriseCLS Enterprise = new();
            using SicpaContext bd = new();
            Enterprise = (
                    from EnterprisesCLS in bd.Enterprises
                    where EnterprisesCLS.Id == id
                    select new EnterpriseCLS()
                    {
                        Id = EnterprisesCLS.Id,
                        Status = EnterprisesCLS.Status.ToString(),
                        Address = EnterprisesCLS.Address,
                        Name = EnterprisesCLS.Name,
                        Phone = EnterprisesCLS.Phone
                    }).First();
            return Ok(Enterprise);
        }
        [HttpPost]
        [Route("Enterprise/SaveEnterprise")]
        public IActionResult SaveEnterprise([FromBody] EnterpriseCLS EnterpriseCLS)
        {

            try
            {
                using SicpaContext bd = new();
                Enterprise oEnterprise = new()
                {
                    Status = bool.Parse(EnterpriseCLS.Status),
                    Address = EnterpriseCLS.Address,
                    Name = EnterpriseCLS.Name,
                    Phone = EnterpriseCLS.Phone,
                    CreatedDate= DateTime.Now,
                };
                bd.Add(oEnterprise);
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(EnterpriseCLS);
        }
        [HttpPut]
        [Route("Enterprise/EditEnterprise/{id}")]
        public IActionResult EditEnterprise([FromBody] EnterpriseCLS EnterpriseCLS, int id)
        {
            try
            {
                using SicpaContext bd = new();
                Enterprise oEnterprise = new()
                {
                    Id = id
                };
                bd.Attach(oEnterprise);
                oEnterprise.Status = bool.Parse(EnterpriseCLS.Status);
                oEnterprise.Address = EnterpriseCLS.Address;
                oEnterprise.Name = EnterpriseCLS.Name;
                oEnterprise.Phone = EnterpriseCLS.Phone;
                oEnterprise.ModifiedDate = DateTime.Now;
                bd.SaveChanges();

            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(EnterpriseCLS);
        }
        [HttpDelete]
        [Route("Enterprise/DeleteEnterprise/{id}")]
        public IActionResult DeleteEnterprise(int id)
        {
            int res = 1;
            try
            {
                using SicpaContext bd = new();
                Enterprise oEnterprise = new()
                {
                    Id = id
                };
                bd.Attach(oEnterprise);
                bd.Enterprises.Attach(oEnterprise);
                bd.Enterprises.Remove(oEnterprise);
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
    

