using Microsoft.AspNetCore.Mvc;

namespace trabalho_np1_pedido.Controllers
{
    [Route("health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> GetHealth()
        {
            return Ok(new { Status = "Ok" });
        }
    }
}
