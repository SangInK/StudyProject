using System.ComponentModel.DataAnnotations;

namespace MyApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "작성이 필요한 항목입니다.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "작성이 필요한 항목입니다.")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "작성이 필요한 항목입니다.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "비밀번호가 서로 일치하지 않습니다.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
