using System.Collections.Generic;
using System.Threading.Tasks;
using Escuela2019.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escuela2019.Services
{
    
    public interface IManager
    {
        
        Task<ActionResult<IEnumerable<Usuario>>> GetUsuario();
        Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario);
        Task<ActionResult<Usuario>> GetUsuario(string identifier);
        Task UpdateUsuario( Usuario usuario);
        Task DeleteUsuario(string identifier);
        Task<ActionResult<Usuario>> GetUsuarioByPhoneNumber(string phoneNumber);
        Task<ActionResult<List<Alerta>>> GetAlerta();
        Task<ActionResult<Alerta>> StoreAlerta(Alerta alerta);
        Task<string> GetNextIdentifier();
        Task<string> GetCode();
    }
}