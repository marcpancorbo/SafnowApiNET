using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
 
namespace Escuela2019.Model
{
    public class Usuario
    {
        public string Name { get; set; }
        [MaxLength(9)]
        public string PhoneNumber { get; set; }
        public List<Alerta> Alertas { get; set; } = new List<Alerta>();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; } 
    }
}