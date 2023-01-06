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
    public class LoaiSpsController : ControllerBase
    {
        lkshopContext db = new lkshopContext();
        

        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var tenloai = formData.Keys.Contains("tenloai") ? (formData["tenloai"]).ToString().Trim() : "";
                var result = from t in db.LoaiSps
                             select new {t.Id, t.TenLoai,t.MoTa,t.TrangThai };
                var kq = result.Where(x => x.TenLoai.Contains(tenloai) && x.TrangThai==true).OrderByDescending(x => x.Id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                return Ok(
                         new ResponseListMessage
                         {
                             page = page,
                             totalItem = kq.Count,
                             pageSize = pageSize,
                             data = kq
                         });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/<LoaiSpsController>/5
        [HttpGet("{id}")]
        public LoaiSp Get(int id)
        {
            LoaiSp loaisp = db.LoaiSps.Where(x=>x.Id ==id).FirstOrDefault();
            return loaisp;
        }
        // GET: api/<LoaiSpsController>
        [HttpGet]
        public IEnumerable<LoaiSp> Get()
        {
            return db.LoaiSps.Where(x => x.TrangThai == true);
        }
        // POST api/<LoaiSpsController>
        [HttpPost]
        public bool Create([FromBody] LoaiSp model)
        {
            if (model.TenLoai == "" || model.MoTa == "")
                return false;
            else
            {
                db.LoaiSps.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        // PUT api/<LoaiSpsController>/5
        [HttpPost()]
        public bool Update([FromBody] LoaiSp model)
        {
            if (model.TenLoai == "" || model.MoTa == "")
                return false;
            else
            {
                LoaiSp l = db.LoaiSps.Where(x => x.Id == model.Id).First();
                l.TenLoai = model.TenLoai;
                l.MoTa = model.MoTa;
                db.SaveChanges();
                return true;
            }
        }

        // DELETE api/<LoaiSpsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            LoaiSp l = db.LoaiSps.Where(x => x.Id == id).FirstOrDefault();
            if(l!= null)
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
