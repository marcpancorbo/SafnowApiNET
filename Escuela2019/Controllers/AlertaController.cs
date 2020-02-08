using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela2019.Model;

namespace Escuela2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly MyContext _context;

        public AlertaController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alerta>>> GetAlerta() => await _context.Alertas.ToListAsync();
        
        [HttpPost]
        public async Task<ActionResult<Alerta>> StoreAlerta(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlerta), new {id = alerta.Id}, alerta);
        }
        
    }
}