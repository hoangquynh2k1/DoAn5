using System.ComponentModel.DataAnnotations;

namespace Admin_Api_BanMayTinh.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}