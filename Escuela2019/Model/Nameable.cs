using System.ComponentModel.DataAnnotations;

namespace Safnow.Model
{
    public class Nameable
    {
        [Key]
        public string Identifier { set; get; }
    }
}