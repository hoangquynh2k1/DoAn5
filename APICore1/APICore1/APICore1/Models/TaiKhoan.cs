using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class TaiKhoan
    {
        public int Id { get; set; }
        public int? IdNv { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? TrangThai { get; set; }
    }
}
