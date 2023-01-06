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
    public class HoaDonBanController : ControllerBase
    {
        private HoaDonBanBUS db = new HoaDonBanBUS();
        // GET: api/<HoaDonBanController>
        [HttpGet("{id}")]
        public HoaDonBanE GetByIdKh(int id)
        {
            return db.GetByIdKh(id);
        }

        // GET api/<HoaDonBanController>/5
        [HttpGet("{id}")]
        public HoaDonBanE Get(int id)
        {
            return db.GetById(id);
        }
        // POST api/<HoaDonBanController>
        [HttpPost]
        public bool Create([FromBody] HoaDonBanE g)
        {
            return db.Create(g);
        }

        // PUT api/<HoaDonBanController>/5
        [HttpPost]
        public bool Update([FromBody] HoaDonBanE g)
        {
            return db.Update(g);
        }

        // DELETE api/<HoaDonBanController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
