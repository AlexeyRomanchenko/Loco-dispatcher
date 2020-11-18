using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.WebAPI.Models.ViewModels
{
    public abstract class UserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}