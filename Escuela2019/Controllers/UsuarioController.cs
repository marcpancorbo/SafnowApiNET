using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela2019.Model;
using Escuela2019.Services;

namespace Escuela2019.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IEscuela2019 _manager;
        public UsuarioController(IEscuela2019 manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuario()
        {
            return await _manager.GetUsuario();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario)
        {
            await _manager.StoreUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            ActionResult<Usuario> usuario = await _manager.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            try
            {
                await _manager.UpdateUsuario(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
          await _manager.DeleteUsuario(id);
            return StatusCode(200);
        }

        [HttpGet]
        [Route("[action]/{phoneNumber}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null)
                return BadRequest();
            ActionResult<Usuario> usuario = await _manager.GetUsuarioByPhoneNumber(phoneNumber);
            if (usuario == null)
                return NotFound();
            return usuario;
        }
    }
    
}