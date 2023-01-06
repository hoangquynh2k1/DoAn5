using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Admin_ElecShop.Entities
{
    public class NhanVienModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool? GioiTinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Cccd { get; set; }
        public string ChucVu { get; set; }
        public string TenNh { get; set; }
        public string Stk { get; set; }
        public bool? TrangThai { get; set; }
    }
}
