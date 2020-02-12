using System.ComponentModel.DataAnnotations;

namespace Escuela2019.Model
{
    public class Nameable
    {
        [Key]
        public string Identifier { set; get; }
    }
}