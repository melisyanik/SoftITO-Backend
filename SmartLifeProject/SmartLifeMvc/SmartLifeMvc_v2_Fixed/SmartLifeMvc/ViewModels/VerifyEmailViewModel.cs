using System.ComponentModel.DataAnnotations;

namespace SmartLifeMvc.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli email giriniz")]
        public string Email { get; set; }
    }
}