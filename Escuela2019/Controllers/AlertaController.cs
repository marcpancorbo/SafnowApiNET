using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Safnow.Model;
using Safnow.Services;

namespace Safnow.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("rest/[controller]")]
    [Authorize]
    public class AlertaController : ControllerBase
    {
        private readonly IManager _manager;

        public AlertaController(IManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alerta>>> GetAlerta() =>await _manager.GetAlerta();
        
        [HttpPost]
        public async Task<ActionResult<Alerta>> StoreAlerta(Alerta alerta)
        {
            await _manager.StoreAlerta(alerta);
            return CreatedAtAction(nameof(GetAlerta), new {id = alerta.Id}, alerta);
        }
        
    }
}