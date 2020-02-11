using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela2019.Model;
using Escuela2019.Services;
using Microsoft.AspNetCore.Authorization;

namespace Escuela2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlertaController : ControllerBase
    {
        private readonly IEscuela2019 _manager;

        public AlertaController(IEscuela2019 manager)
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