using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.WebAPI.Models.ViewModels
{
    public class LoginViewModel : UserViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public new string Username { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public new string Password { get; set; }
    }
}