using System.ComponentModel.DataAnnotations;

namespace CompanyApp.Data.Entities
{
    public class Personel
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required(ErrorMessage = "İsim Alanı Boş Geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim Alanı Boş Geçilemez")]
        [MaxLength(25)]
        public string LastName { get; set; }
        public char Gender { get; set; }
        [Required(ErrorMessage ="Yaş Alanı Boş Geçilemez")]
        [Range(18,63,ErrorMessage ="Yeni eklenecek personelin yaşı 18 ile 63 arasında olmalıdır.")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Adres Alanı Boş Geçilemez")]
        [MaxLength(200)]
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int? CountyId { get; set; }
        public City? Cities { get; set; }
        public County? Counties { get; set; }


    }
}
