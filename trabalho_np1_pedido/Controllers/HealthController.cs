using Microsoft.AspNetCore.Mvc;

namespace trabalho_np1_pedido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetHealth()
        {
            return Ok(new { Status = "Ok" });
        }
    }
}
