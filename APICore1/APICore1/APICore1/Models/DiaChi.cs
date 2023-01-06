using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class DiaChi
    {
        public int Id { get; set; }
        public int? IdKh { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xa { get; set; }
        public string ChiTiet { get; set; }
        public bool? TrangThai { get; set; }
    }
}
