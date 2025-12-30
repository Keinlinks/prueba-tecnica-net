using Clients.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ClientsController : ControllerBase
    {
        readonly ClientLinqService _clientsLinqService;
        readonly ClientsStoreProcedureService _clientsStoredProcedureService;

        public ClientsController(ClientLinqService clientsLinqService, ClientsStoreProcedureService clientsStoredProcedureService)
        {
            _clientsLinqService = clientsLinqService;
            _clientsStoredProcedureService = clientsStoredProcedureService;
        }

        [HttpGet("clients-Linq")]
        public async Task<IActionResult> GetClientsLinq([FromQuery()] int page, [FromQuery()] int pageSize )
        {
            return Ok(await _clientsLinqService.GetClients(page, pageSize));
        }

        [HttpGet("clients-store-procedure")]
        public async Task<IActionResult> GetClientsStoreProcedure([FromQuery()] int page, [FromQuery()] int pageSize)
        {
            return Ok(await _clientsStoredProcedureService.GetClients(page, pageSize));
        }
    }
}
