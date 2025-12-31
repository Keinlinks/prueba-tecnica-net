using Clients.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientsController : ControllerBase
    {
        readonly ClientLinqService _clientsLinqService;
        readonly ClientsStoreProcedureService _clientsStoredProcedureService;

        public ClientsController(ClientLinqService clientsLinqService, ClientsStoreProcedureService clientsStoredProcedureService)
        {
            _clientsLinqService = clientsLinqService;
            _clientsStoredProcedureService = clientsStoredProcedureService;
        }
        [HttpGet]
        [HttpGet("linq")]
        public async Task<IActionResult> GetClientsLinq([FromQuery()] int page, [FromQuery()] int pageSize )
        {
            return Ok(await _clientsLinqService.GetClients(page, pageSize));
        }

        [HttpGet("store-procedure")]
        public async Task<IActionResult> GetClientsStoreProcedure([FromQuery()] int page, [FromQuery()] int pageSize)
        {
            return Ok(await _clientsStoredProcedureService.GetClients(page, pageSize));
        }
    }
}
