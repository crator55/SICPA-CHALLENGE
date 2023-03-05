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
        private readonly Enterprise enterprise = new();
        public EnterpriseController(ILogger<EnterpriseController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Enterprise/ListEnterprise")]
        public IActionResult ListEnterprise()
        {
            var list = enterprise.ListEnterprise();
            return Ok(list);
        }
        [HttpGet]
        [Route("Enterprise/OneEnterprise/{id}")]
        public IActionResult OneEnterprise(int id)
        {
            var result = enterprise.OneEnterprise(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("Enterprise/SaveEnterprise")]
        public IActionResult SaveEnterprise([FromBody] EnterpriseCLS EnterpriseCLS)
        {
            bool resul = false;
            try
            {
                resul = enterprise.SaveEnterprise(EnterpriseCLS);
            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(resul);
        }
        [HttpPut]
        [Route("Enterprise/EditEnterprise/{id}")]
        public IActionResult EditEnterprise([FromBody] EnterpriseCLS EnterpriseCLS, int id)
        {
            bool resul = false;
            try
            {
                resul = enterprise.EditEnterprise(EnterpriseCLS, id);
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
            bool res =false;
            try
            {
                res = enterprise.DeleteEnterprise(id);
            }
            catch (Exception ex)
            {
                Conflict(ex);
            }
            return Ok(res);
        }
    }
}


