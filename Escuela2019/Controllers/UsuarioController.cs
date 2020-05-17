using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safnow.Model;
using Safnow.Services;

namespace Safnow.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("rest/")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IManager _manager;
        public UsuarioController(IManager manager)
        {
            _manager = manager;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("[controller]")]
        public async Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario)
        {
            ActionResult<Usuario> usuario1 = await _manager.GetUsuarioByPhoneNumber(usuario.PhoneNumber);
            if (usuario1.Value == null)
            {
                usuario.Identifier = await _manager.GetNextIdentifier();
                usuario.VerificationCode = _manager.GetCode().Result;
                await _manager.StoreUsuario(usuario);
            }
            else
            {
                usuario.VerificationCode = _manager.GetCode().Result;
            }
            //_manager.SendVerificationCode(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Identifier}, usuario);
        }
        
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _manager.GetUsuario();
        }
        
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(String id)
        {
            ActionResult<Usuario> usuario = await _manager.GetUsuario(id);
            if (usuario.Value == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> UpdateUsuario(string id, Usuario usuario)
        {
            if (!id.Equals(usuario.Identifier))
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
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Identifier }, usuario);

        }
        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(string id)
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