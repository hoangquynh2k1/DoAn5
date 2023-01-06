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
    public class KhachHangController : ControllerBase
    {
        private KhachHangBUS db = new KhachHangBUS();
        // GET api/<KhachHangController>/5
        [HttpGet("{id}")]
        public KhachHangE Get(int id)
        {
            return db.GetById(id);
        }
        // POST api/<KhachHangController>
        [HttpPost]
        public bool Create([FromBody] KhachHangE g)
        {
            return db.Create(g);
        }

        // PUT api/<KhachHangController>/5
        [HttpPut("{id}")]
        public bool Update([FromBody] KhachHangE g)
        {
            return db.Update(g);
        }

        // DELETE api/<KhachHangController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
