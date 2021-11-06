using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}