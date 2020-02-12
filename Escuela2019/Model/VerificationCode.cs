using System.ComponentModel.DataAnnotations;

namespace Escuela2019.Model
{
    public class VerificationCode : Identifiable
    {
        [MaxLength(5)]
        public string Code { set; get; }
    }
}