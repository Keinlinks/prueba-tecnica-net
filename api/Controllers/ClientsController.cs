using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ClientsController : ControllerBase
    {
        public IActionResult getClients()
        {
            return Ok();
        }
    }
}
