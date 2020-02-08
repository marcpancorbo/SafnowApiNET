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
    public class UsuarioController : ControllerBase
    {
        private readonly MyContext _context;

        public UsuarioController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Usuario>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario)
        {
            Alerta alerta = new Alerta
            {
                Name = "Alerta1"
            };
            usuario.Alertas.Add(alerta);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
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
            _context.Entry(usuario).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
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
            ActionResult<Usuario> usuario = await GetUsuario(id);
            _context.Usuarios.Remove(usuario.Value);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpGet]
        [Route("[action]/{phoneNumber}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null)
                return BadRequest();
            Usuario usuario =  await _context.Usuarios.Where(u => u.PhoneNumber == phoneNumber).Include(u => u.Alertas
             ).FirstOrDefaultAsync();
            if (usuario == null)
                return NotFound();
            return usuario;
        }
    }
    
}