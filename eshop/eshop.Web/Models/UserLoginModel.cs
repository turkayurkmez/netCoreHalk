

using System.ComponentModel.DataAnnotations;

namespace eshop.Web.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adını giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
