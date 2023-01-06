using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.Entities
{
    public class GioHangE
    {
        public int? Id { get; set; }
        public int? IdKh { get; set; }
        public DateTime? NgayDat { get; set; }
        public bool? TrangThai { get; set; }
        public List<CtGioHang> CtGioHangs { get; set; }
        public GioHangE()
        {

        }
        public GioHangE(GioHang g,List<CtGioHang> ctGio)
        {
            if (g == null || ctGio == null)
            {

            }
            else
            {
                Id = g.Id;
                IdKh = g.IdKh;
                NgayDat = g.NgayDat;
                TrangThai = g.TrangThai;
                CtGioHangs = ctGio;
            }
        }
    }
}
