using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.WebAPI.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Пожалуйста, введите логин")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Пожалуйста, введите пароль")]
        public string Password { get; set; }
    }
}