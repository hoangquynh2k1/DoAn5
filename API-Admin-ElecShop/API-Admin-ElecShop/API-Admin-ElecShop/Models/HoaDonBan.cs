using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class HoaDonBan
    {
        public int Id { get; set; }
        public int? IdKh { get; set; }
        public int? IdDiaChi { get; set; }
        public DateTime? NgayDat { get; set; }
        public short? TinhTrangDh { get; set; }
        public bool? TrangThai { get; set; }
    }
}
