using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class LoaiSp
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
    }
}
