using System.ComponentModel.DataAnnotations;

namespace Safnow.Model
{
    public class VerificationCode : Identifiable
    {
        [MaxLength(5)]
        public string Code { set; get; }
    }
}