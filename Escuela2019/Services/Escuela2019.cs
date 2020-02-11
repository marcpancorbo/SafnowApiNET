using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela2019.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escuela2019.Services
{
    public class Escuela2019 : IEscuela2019
    {
        private readonly MyContext _context;

        public Escuela2019(MyContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario)
        {
            Alerta alerta = new Alerta
            {
                Name = "Prueba"
            };
            usuario.Alertas.Add(alerta);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            ActionResult<Usuario> usuario = await GetUsuario(id);
            _context.Usuarios.Remove(usuario.Value);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Usuario>> GetUsuarioByPhoneNumber(string phoneNumber)
        {
            Usuario usuario =  await _context.Usuarios.Where(u => u.PhoneNumber == phoneNumber).Include(u => u.Alertas
            ).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<ActionResult<List<Alerta>>> GetAlerta() => await _context.Alertas.ToListAsync();
        public async Task<ActionResult<Alerta>> StoreAlerta(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
            return alerta;
        }
    }
}