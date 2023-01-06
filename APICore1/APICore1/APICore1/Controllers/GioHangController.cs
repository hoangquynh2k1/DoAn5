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
    public class GioHangController : ControllerBase
    {
        private GioHangBUS db = new GioHangBUS();
        // GET: api/<GioHangController>
        [HttpGet("{id}")]
        public GioHangE GetByIdKh(int id)
        {
            return db.GetByIdKh(id);
        }

        // GET api/<GioHangController>/5
        [HttpGet("{id}")]
        public GioHangE Get(int id)
        {
            return db.GetById(id);
        }
        // POST api/<GioHangController>
        [HttpPost]
        public bool Create([FromBody] GioHangE g)
        {
            return db.Create(g);
        }

        // PUT api/<GioHangController>/5
        [HttpPost]
        public bool Update([FromBody] GioHangE g)
        {
            return db.Update(g);
        }

        // DELETE api/<GioHangController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
