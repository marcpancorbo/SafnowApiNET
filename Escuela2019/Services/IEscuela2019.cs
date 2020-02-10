using System.Collections.Generic;
using System.Threading.Tasks;
using Escuela2019.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escuela2019.Services
{
    
    public interface IEscuela2019
    {
        
        Task<ActionResult<List<Usuario>>> GetUsuario();
        Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario);
        Task<ActionResult<Usuario>> GetUsuario(int id);
        Task UpdateUsuario( Usuario usuario);
        Task DeleteUsuario(int id);
        Task<ActionResult<Usuario>> GetUsuarioByPhoneNumber(string phoneNumber);
        Task<ActionResult<List<Alerta>>> GetAlerta();
        Task<ActionResult<Alerta>> StoreAlerta(Alerta alerta);
    }
}