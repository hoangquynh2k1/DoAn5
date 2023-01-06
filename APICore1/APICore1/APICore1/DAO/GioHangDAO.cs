using API_Elec_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Entities;

namespace API_Elec_Shop.DAO
{
    public class GioHangDAO
    {
        lkshopContext db = new lkshopContext();
        public GioHangE GetById(int id)
        {
            GioHang result = db.GioHangs.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<CtGioHang> list = db.CtGioHangs.Where(x => x.IdGioHang == result.Id && x.TrangThai == true).ToList();
            GioHangE giohang = new GioHangE(result, list);
            return giohang;
        }
        public GioHangE GetByIdKh(int id)
        {
            GioHang result = db.GioHangs.Where(x => x.IdKh == id && x.TrangThai == true).FirstOrDefault();
            List<CtGioHang> list;
            if(result==null)
            {
                list = new List<CtGioHang>();
            } 
            else
            {
                list = db.CtGioHangs.Where
                (x => x.IdGioHang == result.Id && x.TrangThai == true).ToList();
            }
            GioHangE giohang = new GioHangE(result, list);
            return giohang;
        }
        public bool Create(GioHangE g)
        {
            if (g != null && g.Id==-1)
            {
                GioHang gioHang = new GioHang();
                gioHang.IdKh = g.IdKh;
                gioHang.NgayDat = g.NgayDat;
                gioHang.TrangThai = g.TrangThai;
                db.GioHangs.Add(gioHang);
                //for (int i = 0; i < g.CtGioHangs.Count; i++)
                //{
                //    db.CtGioHangs.Add(g.CtGioHangs[i]);
                //}
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(GioHangE g)
        {
            if (g != null)
            {
                GioHang gioHang = db.GioHangs.Where
                    (x => x.Id == g.Id && x.TrangThai == true).FirstOrDefault();
                gioHang.IdKh = g.IdKh;
                gioHang.NgayDat = g.NgayDat;
                gioHang.TrangThai = g.TrangThai;
                List<CtGioHang> list = db.CtGioHangs.Where(x => x.IdGioHang == g.Id && x.TrangThai == true).ToList();
                if (list.Count < g.CtGioHangs.Count)
                {
                    for (int i = 0; i < g.CtGioHangs.Count; i++)
                    {
                        bool ch = false;
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (g.CtGioHangs[i].Id == list[j].Id)
                            {
                                list[j] = g.CtGioHangs[i];
                                ch = true;
                            }
                        }
                        if(!ch)
                            db.CtGioHangs.Add(g.CtGioHangs[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        bool ch = false;
                        for (int j = 0; j < g.CtGioHangs.Count; j++)
                        {
                            if (g.CtGioHangs[j].Id == list[i].Id)
                            {
                                list[i] = g.CtGioHangs[j];
                                ch = true;
                                break;
                            }
                        }
                        if (!ch)
                        {
                            list[i].TrangThai=false;
                        }
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
        public bool Delete(int id)
        {
            GioHang result = db.GioHangs.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            if (result != null)
            {            
                List<CtGioHang> list = db.CtGioHangs.Where
                (x => x.IdGioHang == result.Id && x.TrangThai == true).ToList();

                result.TrangThai = false;
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
