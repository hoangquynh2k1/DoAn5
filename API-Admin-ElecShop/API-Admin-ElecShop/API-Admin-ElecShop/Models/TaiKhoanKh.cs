using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class TaiKhoanKh
    {
        public int Id { get; set; }
        public int? IdKh { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? TrangThai { get; set; }

        public virtual KhachHang IdKhNavigation { get; set; }
    }
}
