using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.WebAPI.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Пожалуйста, введите логин пользователя")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пароль пользователя")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
    }
}