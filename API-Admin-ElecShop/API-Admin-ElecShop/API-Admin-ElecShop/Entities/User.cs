using System.ComponentModel.DataAnnotations;

namespace API_Admin_ElecShop.Entities
{
    public class User
    {
        public int? MaNguoiDung { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string Role { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string Token { get; set; }
    }
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
