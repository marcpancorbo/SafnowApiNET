using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safnow.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace Safnow.Services
{
    public class Manager : IManager
    {
        private readonly MyContext _context;
        private static readonly Regex PATTERN = new Regex("(User)(\\d*)$");
        public Manager(MyContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<ActionResult<Usuario>> StoreUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<ActionResult<Usuario>> GetUsuario(string identifier)
        {
            return await _context.Usuarios.FindAsync(identifier);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(string identifier)
        {
            ActionResult<Usuario> usuario = await GetUsuario(identifier);
            _context.Usuarios.Remove(usuario.Value);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Usuario>> GetUsuarioByPhoneNumber(string phoneNumber)
        {
            Usuario usuario = await _context.Usuarios.Where(u => u.PhoneNumber == phoneNumber).Include(u => u.Alertas
            ).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<ActionResult<List<Alerta>>> GetAlerta() => await _context.Alertas.ToListAsync();

        public async Task<ActionResult<Alerta>> StoreAlerta(Alerta alerta)
        {
            alerta.Usuario = await _context.Usuarios.Where(u => u.PhoneNumber == alerta.Usuario.PhoneNumber).FirstOrDefaultAsync();
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
            SendMessage(alerta);
            return alerta;
        }

        public async Task<string> GetNextIdentifier()
        {
            List<Usuario> userList = await _context.Usuarios.OrderByDescending(u => u.Identifier).ToListAsync();
            if (!userList.Any())
                return "User00000";
            Usuario user = userList[0];
            string identifier = user.Identifier;
            if (PATTERN.IsMatch(identifier))
            {
                string numbers = PATTERN.Match(identifier).Groups[2].Value;
                int num = Int32.Parse(numbers) + 1;
                string pattern = num.ToString();
                string adg = "User" + Regex.Replace(pattern, "[0-9]+", match => match.Value.PadLeft(5, '0'));
                return adg;
            }
            return null;
        }

        public async Task<string> GetCode()
        {
            var qry = await _context.Codes.FromSqlRaw("select Code from safnowNET.Codes").CountAsync();
            int index = new Random().Next(qry);
            ActionResult<VerificationCode> code = await _context.Codes.Skip(index).FirstOrDefaultAsync();
            return code.Value.Code;
        }

        public void SendMessage(Alerta alerta)
        {
            const string accountSid = "AC4f086e627dc9cdf23e0ebaeb8a119671";
            const string authToken = "d482c47e827d310e62cc38dbe34fd8c7";
            TwilioClient.Init(accountSid, authToken);
            foreach( var phoneNumber in alerta.To)
            {
                var towho = new PhoneNumber("+34" + phoneNumber);
                var message = MessageResource.Create(
                    towho,
                    from: new PhoneNumber("+12073863419"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).  
                    body: $"Tu contacto "+alerta.Usuario.Name+" con teléfono "+alerta.Usuario.PhoneNumber+" está en peligro! Puedes encontrar su ubicación mediante estos parámetros latitud: "+alerta.Ubication.Latitude+" longitud: "+alerta.Ubication.Altitude);
            }
            
        }

        public void SendVerificationCode(Usuario usuario)
        {
            const string accountSid = "AC4f086e627dc9cdf23e0ebaeb8a119671";
            const string authToken = "d482c47e827d310e62cc38dbe34fd8c7";
            TwilioClient.Init(accountSid, authToken);
                var towho = new PhoneNumber("+34" + usuario.PhoneNumber);
                var message = MessageResource.Create(
                    towho,
                    from: new PhoneNumber("+12073863419"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).  
                    body: $"Tu código de verificación es: "+usuario.VerificationCode);
        }
    }

}