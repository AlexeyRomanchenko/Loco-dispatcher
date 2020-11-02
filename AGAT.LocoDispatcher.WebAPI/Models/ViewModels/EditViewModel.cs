using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.WebAPI.Models.ViewModels
{
    public class EditViewModel : UserViewModel
    {
        [Required(ErrorMessage = "Пользователь неопределен")]
        public int Id { get; set; }
        public string ConfirmPassword { get; set; }
        public new string Password { get; set; }
        public int RoleId { get; set; }
        public string StationCode {get;set;}
    }
}