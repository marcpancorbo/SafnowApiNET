using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safnow.Model
{
    public class Alerta : Identifiable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string Name { set; get; }
        public Usuario Usuario { set; get; }
        public Ubication Ubication { set; get; }
        [NotMapped]
        public List<String> To { set; get; }
    }
}