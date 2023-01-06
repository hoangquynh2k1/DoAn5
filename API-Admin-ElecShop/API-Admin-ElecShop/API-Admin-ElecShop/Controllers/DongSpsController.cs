using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Admin_ElecShop.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class DongSpsController : ControllerBase
    {
        lkshopContext db = new lkshopContext();
        // GET: api/<DongSpsController>
        [HttpGet]
        public IEnumerable<DongSp> Get()
        {
            return db.DongSps.ToList<DongSp>();
        }
        [HttpGet("{id}")]
        public IEnumerable<DongSp> GetByIdLoai(int id)
        {
            return db.DongSps.Where(x=>x.IdLoai==id && x.TrangThai==true).ToList<DongSp>();
        }
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
       {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var tenDong = formData.Keys.Contains("tenDong") ? (formData["tenDong"]).ToString().Trim() : "";
                var loai = formData.Keys.Contains("idLoai")? (formData["idLoai"]).ToString(): "0";
                var idloai = 0;
                var result = from t in db.DongSps
                             join l in db.LoaiSps on t.IdLoai equals l.Id
                             where l.TrangThai == true && t.TrangThai == true
                             select new { t.Id, t.TenDong, t.IdLoai, t.NamSx, t.HangSx, t.TrangThai };
                if (loai == "0")
                {
                    var kq = result.Where(x => x.TenDong.Contains(tenDong)).OrderByDescending(x => x.Id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                    return Ok(
                         new ResponseListMessage
                         {
                             page = page,
                             totalItem = kq.Count,
                             pageSize = pageSize,
                             data = kq
                         });
                }
                else
                {
                    idloai = int.Parse(loai);
                    var kq = result.Where(x => x.TenDong.Contains(tenDong) && x.IdLoai == idloai).OrderByDescending(x => x.Id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                    return Ok(
                         new ResponseListMessage
                         {
                             page = page,
                             totalItem = kq.Count,
                             pageSize = pageSize,
                             data = kq
                         });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/<DongSpsController>/5
        [HttpGet("{id}")]
        public DongSp Get(int id)
        {
            DongSp Dongsp = db.DongSps.Where(x=>x.Id ==id && x.TrangThai == true).FirstOrDefault();
            return Dongsp;
        }

        // POST api/<DongSpsController>
        [HttpPost]
        public bool Create([FromBody] DongSp model)
        {
            if (model.TenDong == "" || model.NamSx < 2016)
                return false;
            else
            {
                db.DongSps.Add(model);
                db.SaveChanges();
                return true;
            }    
        }

        // PUT api/<DongSpsController>/5
        [HttpPost()]
        public bool Update([FromBody] DongSp model)
        {
            if (model.TenDong == "" || model.NamSx < 1900)
                return false;
            else
            {
                DongSp l = db.DongSps.Where(x => x.Id == model.Id).First();
                l.TenDong = model.TenDong;
                l.NamSx = model.NamSx;
                db.SaveChanges();
                return true;
            }    
        }

        // DELETE api/<DongSpsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            LoaiSp l = db.LoaiSps.Where(x => x.Id == id).FirstOrDefault();
            if (l != null)
            {
                l.TrangThai = false;
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
