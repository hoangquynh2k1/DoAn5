using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.BUS;
using API_Elec_Shop.Models;
using API_Elec_Shop.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Elec_Shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private SanPhamBUS db = new SanPhamBUS();
        lkshopContext db1 = new lkshopContext();
        // GET: api/<DongSanPhamController>
        [HttpGet]
        public List<SanPham> Get()
        {
            return db.GetAll();
        }

        // GET api/<DongSanPhamController>/5
        [HttpGet("{id}")]
        public SanPham Get(int id)
        {
            return db.GetById(id);
        }
        [HttpGet("{id}")]
        public List<SanPham> GetByIdDong(int id)
        {
            return db.GetByIdDong(id);
        }
        // POST api/<DongSanPhamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int? ma_danh_muc = null;
                string loc = "";
                if (formData.Keys.Contains("loc") && !string.IsNullOrEmpty(Convert.ToString(formData["loc"]))) { loc = formData["loc"].ToString(); }
                if (formData.Keys.Contains("ma_danh_muc") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_danh_muc"]))) 
                    { ma_danh_muc = int.Parse(formData["ma_danh_muc"].ToString()); }
                List<SanPham> list = db.GetAll();
                long total = list.Count();
                list=list.Where(x => (x.IdDong == ma_danh_muc  || ma_danh_muc ==null)
                    && (x.TenSp.ToLower()).Contains(loc.ToLower())).
                    Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                //switch (loc)
                //{
                //    case "TD":
                //        result2 = result1.OrderBy(x => x.GiaBan).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                //        break;
                //    case "GD":
                //        result2 = result1.OrderByDescending(x => x.GiaBan).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                //        break;
                //    default:
                //        result2 = result1.OrderByDescending(x => x.GiaBan).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                //        break;
                //}
                return Ok(
                           new KQ
                           {
                               page = page,  totalItem = total,   pageSize = pageSize,   data = list
                           }
                         );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public class KQ
        {
            public int page { get; set; }
            public int pageSize { get; set; }
            public long totalItem { get; set; }
            public dynamic data { get; set; }
        }
    }
}
