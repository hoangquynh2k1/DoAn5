using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
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
