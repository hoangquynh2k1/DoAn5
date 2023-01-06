using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.BUS;
using API_Elec_Shop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Elec_Shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CtGioHangController : ControllerBase
    {
        private CtGioHangBUS db = new CtGioHangBUS();
        // GET api/<CtGioHangController>/5
        [HttpGet("{id}")]
        public CtGioHang Get(int id)
        {
            return db.GetById(id);
        }
        [HttpGet("{id}")]
        public List<CtGioHang> GetByIdGio(int id)
        {
            return db.GetByIdGio(id);
        }
        // POST api/<CtGioHangController>
        [HttpPost]
        public bool Create([FromBody] CtGioHang g)
        {
            return db.Create(g);
        }

        // PUT api/<CtGioHangController>/5
        [HttpPut("{id}")]
        public bool Update([FromBody] CtGioHang g)
        {
            return db.Update(g);
        }

        // DELETE api/<CtGioHangController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
