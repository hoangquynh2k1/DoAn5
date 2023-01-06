using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.DAO
{
    public class HoaDonBanDAO
    {
        lkshopContext db = new lkshopContext();
        public List<HoaDonBanModel> GetList()
        {
            List<HoaDonBanModel> list = new List<HoaDonBanModel>();
            List<HoaDonBan> objs = db.HoaDonBans.Where(x => x.TrangThai == true).ToList();
            for (int i = 0; i < objs.Count; i++)
            {
                List<CtHoaDonBan> anhs = db.CtHoaDonBans.Where(x => x.IdHoaDonBan == objs[i].Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where(x => x.IdSp == objs[i].Id && x.TrangThai == true).ToList();
                Gium gium = db.Gia.Where(x => x.IdSp == objs[i].Id && x.TrangThai == true).FirstOrDefault();
                HoaDonBanModel obj = new HoaDonBanModel(objs[i], anhs);
                list.Add(obj);
            }
            return list;
        }
        public HoaDonBanModel GetById(int id)
        {
            HoaDonBan result = db.HoaDonBans.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<CtHoaDonBan> list = db.CtHoaDonBans.Where
                (x => x.IdHoaDonBan == result.Id && x.TrangThai == true).ToList();
            HoaDonBanModel hoaDon = new HoaDonBanModel(result,list);
            return hoaDon;
        }
        public HoaDonBanModel GetByIdKh(int id)
        {
            HoaDonBan result = db.HoaDonBans.Where(x => x.IdKh == id && x.TrangThai == true).OrderByDescending(x=> x.Id).FirstOrDefault();
            List<CtHoaDonBan> list = db.CtHoaDonBans.Where
                (x => x.IdHoaDonBan == result.Id && x.TrangThai == true).ToList();
            HoaDonBanModel hoaDon = new HoaDonBanModel(result, list);
            return hoaDon;
        }
        public bool Create(HoaDonBanModel h)
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
        public bool Update(HoaDonBanModel h)
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
