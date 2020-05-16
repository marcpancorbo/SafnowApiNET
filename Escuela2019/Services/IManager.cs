using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safnow.Model;

namespace Safnow.Services
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
        void SendMessage(Alerta alerta);
        void SendVerificationCode(Usuario usuario);

    }
}