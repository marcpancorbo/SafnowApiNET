using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
 
namespace Escuela2019.Model
{
    public class Usuario : Nameable
    {
        public string Name { get; set; }
        [MaxLength(9)]
        [Index(IsUnique = true)]
        public string PhoneNumber { get; set; }
        public List<Alerta> Alertas { get; set; } = new List<Alerta>();
        public bool Verificated { set; get; }
        public string VerificationCode { set; get; }

        public void Copy(Usuario usuario)
        {
            Name = usuario.Name;
            PhoneNumber = usuario.PhoneNumber;
        }
    }
}