using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class CTHDBModel
    {
        public int Id { get; set; }
        public string TenSp { get; set; }
        public string DuongDan { get; set; }
        public int SoLuong { get; set; }
        public CTHDBModel()
        {

        }
        public CTHDBModel(List<CtHoaDonBan> list)
        {
            list = list.OrderByDescending(x => x.IdSp).ToList();
        }
    }
}
