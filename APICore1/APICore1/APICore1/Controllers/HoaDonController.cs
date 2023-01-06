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
    public class HoaDonController : ControllerBase
    {
        private HoaDonBUS db = new HoaDonBUS();
        // GET api/<HoaDonController>/5
        [HttpGet("{id}")]
        public HoaDonBan Get(int id)
        {
            return db.GetById(id);
        }
        //[HttpGet("{id}")]
        //public List<HoaDon> GetByIdLoai(int id)
        //{
        //    return db.GetByIdLoai(id);
        //}
        // POST api/<HoaDonController>
        [HttpPost]
        public bool Create([FromBody] HoaDonBan g)
        {
            return db.Create(g);
        }

        // PUT api/<HoaDonController>/5
        [HttpPut("{id}")]
        public bool Update([FromBody] HoaDonBan g)
        {
            return db.Update(g);
        }

        // DELETE api/<HoaDonController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
