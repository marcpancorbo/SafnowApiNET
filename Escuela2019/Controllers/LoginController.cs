using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Escuela2019.Model;
using Escuela2019.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Escuela2019.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEscuela2019 _manager;
        
        // TRAEMOS EL OBJETO DE CONFIGURACIÓN (appsettings.json)
        // MEDIANTE INYECCIÓN DE DEPENDENCIAS.
        public LoginController(IConfiguration configuration, IEscuela2019 manager)
        {
            this._configuration = configuration;
            this._manager = manager;
        }

        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var _userInfo = await AutenticarUsuarioAsync(usuario.PhoneNumber, usuario.Name);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }

        // COMPROBAMOS SI EL USUARIO EXISTE EN LA BASE DE DATOS 
        private async Task<Usuario> AutenticarUsuarioAsync(string phoneNumber, string code)
        {
            // AQUÍ LA LÓGICA DE AUTENTICACIÓN //

            // Supondremos que el Usuario existe en la Base de Datos.
            // Retornamos un objeto del tipo UsuarioInfo, con toda
            // la información del usuario necesaria para el Token.
            ActionResult<Usuario> result = await _manager.GetUsuarioByPhoneNumber(phoneNumber);
            return result.Value;
        }

        // GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO
        private string GenerarTokenJWT(Usuario usuario)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, usuario.PhoneNumber), 
                new Claim("nombre", usuario.Name),
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }        
    }
}