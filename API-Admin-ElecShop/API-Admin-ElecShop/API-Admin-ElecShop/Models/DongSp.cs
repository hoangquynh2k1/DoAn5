using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class DongSp
    {
        public int Id { get; set; }
        public int? IdLoai { get; set; }
        public string TenDong { get; set; }
        public int? NamSx { get; set; }
        public string HangSx { get; set; }
        public bool? TrangThai { get; set; }
    }
}
