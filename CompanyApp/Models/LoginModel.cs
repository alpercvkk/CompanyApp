using System.ComponentModel.DataAnnotations;

namespace CompanyApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Parola Alanı boş geçilemez")]
        [MinLength(8,ErrorMessage ="Parola min 8 karakter uzunluğunda olmalıdır")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } // Oturum kalıcı olsun mu olmasın mı? Cookie silinemeyecek ben güvenli çıkış yapana kadar
    } 
}
