using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.WebAPI.Models.ViewModels
{
    public class RegisterViewModel: UserViewModel
    {
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public string StationCode { get; set; }
        public int RoleId { get; set; }
    }
}