using System.ComponentModel.DataAnnotations;

namespace MyApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "작성이 필요한 항목입니다.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "작성이 필요한 항목입니다.")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
