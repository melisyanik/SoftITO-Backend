using System.ComponentModel.DataAnnotations;

namespace SmartLifeMvc.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli email giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yeni şifre zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalı")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre tekrar zorunludur")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmNewPassword { get; set; }
    }
}