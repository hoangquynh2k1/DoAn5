using API_Elec_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Entities;

namespace API_Elec_Shop.DAO
{
    public class HoaDonBanDAO
    {
        lkshopContext db = new lkshopContext();
        public HoaDonBanE GetById(int id)
        {
            HoaDonBan result = db.HoaDonBans.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<CtHoaDonBan> list = db.CtHoaDonBans.Where
                (x => x.IdHoaDonBan == result.Id && x.TrangThai == true).ToList();
            HoaDonBanE hoaDon = new HoaDonBanE(result,list);
            return hoaDon;
        }
        public HoaDonBanE GetByIdKh(int id)
        {
            HoaDonBan result = db.HoaDonBans.Where(x => x.IdKh == id && x.TrangThai == true).OrderByDescending(x=> x.Id).FirstOrDefault();
            List<CtHoaDonBan> list = db.CtHoaDonBans.Where
                (x => x.IdHoaDonBan == result.Id && x.TrangThai == true).ToList();
            HoaDonBanE hoaDon = new HoaDonBanE(result, list);
            return hoaDon;
        }
        public bool Create(HoaDonBanE h)
        {
            if(h!=null)
            {
                HoaDonBan hoaDon = new HoaDonBan();
                hoaDon.IdKh = h.IdKh;
                hoaDon.IdDiaChi = h.IdDiaChi;
                hoaDon.NgayDat = h.NgayDat;
                hoaDon.TinhTrangDh = h.TinhTrangDh;
                hoaDon.TrangThai = h.TrangThai;
                db.HoaDonBans.Add(hoaDon);
                if(h.CtHoaDonBans==null)
                {
                    
                } 
                else
                {
                    for (int i = 0; i < h.CtHoaDonBans.Count; i++)
                    {
                        db.CtHoaDonBans.Add(h.CtHoaDonBans[i]);
                    }
                }    
                db.SaveChanges();
                return true;
            }    
            else
            {
                return false;
            }    
        }
        public bool Update(HoaDonBanE h)
        {
            HoaDonBan hoaDon = db.HoaDonBans.Where(x => x.Id == h.Id && x.TrangThai == true).FirstOrDefault();
            if (hoaDon != null)
            {
                hoaDon.Id = h.Id;
                hoaDon.IdKh = h.IdKh;
                hoaDon.IdDiaChi = h.IdDiaChi;
                hoaDon.NgayDat = h.NgayDat;
                hoaDon.TinhTrangDh = h.TinhTrangDh;
                hoaDon.TrangThai = h.TrangThai;
                for (int i = 0; i < h.CtHoaDonBans.Count; i++)
                {
                    CtHoaDonBan ct = db.CtHoaDonBans.Where
                        (x => x.Id == h.CtHoaDonBans[i].Id && x.TrangThai == true).FirstOrDefault();
                    if (ct == null)
                        db.CtHoaDonBans.Add(h.CtHoaDonBans[i]);
                    else
                        ct = h.CtHoaDonBans[i];
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            HoaDonBan hoaDon = db.HoaDonBans.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<CtHoaDonBan> list = db.CtHoaDonBans.Where
                (x => x.IdHoaDonBan == hoaDon.Id && x.TrangThai == true).ToList();
            if (hoaDon != null)
            {
                hoaDon.TrangThai = false;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].TrangThai = false;
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
