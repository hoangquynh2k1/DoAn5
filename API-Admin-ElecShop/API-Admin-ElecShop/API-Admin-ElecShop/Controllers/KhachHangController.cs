using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;
using API_Admin_ElecShop.DAO;
using API_Admin_ElecShop.Entities;

namespace API_Admin_ElecShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private KhachHangDAO db = new KhachHangDAO();
        // GET api/<CtGioHangController>/5
        [HttpGet]
        public List<KhachHangModel> Get()
        {
            return db.GetList();
        }
        [HttpGet("{id}")]
        public KhachHangModel Get(int id)
        {
            return db.GetById(id);
        }
        // POST api/<CtGioHangController>
        [HttpPost]
        public bool Create([FromBody] KhachHangModel o)
        {
            return db.Create(o);
        }

        // PUT api/<CtGioHangController>/5
        [HttpPut("{id}")]
        public bool Update([FromBody] KhachHangModel o)
        {
            return db.Update(o);
        }

        // DELETE api/<CtGioHangController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
