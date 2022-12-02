using System.ComponentModel.DataAnnotations;

namespace eshop.API.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
