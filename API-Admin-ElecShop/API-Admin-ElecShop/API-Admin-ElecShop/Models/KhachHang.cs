using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            TaiKhoanKhs = new HashSet<TaiKhoanKh>();
        }

        public int Id { get; set; }
        public string HoTen { get; set; }
        public short? NamSinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public bool? GioiTinh { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<TaiKhoanKh> TaiKhoanKhs { get; set; }
    }
}
