

using System.ComponentModel.DataAnnotations;

namespace RenderHTMLWithRazor.Models
{
    public class ResponseModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        [MinLength(3, ErrorMessage = "İsminiz en az üç harften oluşmalı")]
        public string Name { get; set; }

        public string? LastName { get; set; }
        [Required(ErrorMessage = "Katılım durumunu belirtiniz!")]
        public bool IsParticipant { get; set; }


        [EmailAddress(ErrorMessage = "E-posta formatına uyan bir adres giriniz....")]
        [Required(ErrorMessage = "Eposta adresi boş olamaz")]
        public string Email { get; set; }
    }
}
