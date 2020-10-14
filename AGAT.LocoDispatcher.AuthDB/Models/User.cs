using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGAT.LocoDispatcher.AuthDB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Index(IsUnique =true)]
        public string Username { get; set; }
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
