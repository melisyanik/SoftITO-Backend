using Microsoft.AspNetCore.Identity;

namespace BiletSinema.Models
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = "DuplicateEmail", Description = $"'{email}' e-posta adresi zaten kullanılıyor." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = "DuplicateUserName", Description = $"'{userName}' kullanıcı adı zaten kullanılıyor." };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = "InvalidEmail", Description = "Geçersiz e-posta adresi." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = "InvalidUserName", Description = "Geçersiz kullanıcı adı, sadece harf ve rakam içerebilir." };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = "PasswordRequiresDigit", Description = "Şifre en az bir rakam ('0'-'9') içermelidir." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = "PasswordRequiresLower", Description = "Şifre en az bir küçük harf ('a'-'z') içermelidir." };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifre en az bir özel karakter (örn: !@#$%^&*) içermelidir." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = "PasswordRequiresUpper", Description = "Şifre en az bir büyük harf ('A'-'Z') içermelidir." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = "PasswordTooShort", Description = $"Şifre en az {length} karakter uzunluğunda olmalıdır." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = "PasswordMismatch", Description = "Girdiğiniz şifreler eşleşmiyor." };
        }
        
        public override IdentityError DefaultError()
        {
            return new IdentityError { Code = "DefaultError", Description = "Bilinmeyen bir hata oluştu." };
        }
    }
}
