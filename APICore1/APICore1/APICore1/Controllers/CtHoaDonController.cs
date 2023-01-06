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
    public class CtHoaDonBanController : ControllerBase
    {
        private CtHoaDonBanBUS db = new CtHoaDonBanBUS();

        // GET api/<CtHoaDonBanController>/5
        [HttpGet("{id}")]
        public CtHoaDonBan Get(int id)
        {
            return db.GetById(id);
        }
        //[HttpGet("{id}")]
        //public List<CtHoaDonBan> GetByIdLoai(int id)
        //{
        //    return db.GetByIdLoai(id);
        //}
        // POST api/<CtHoaDonBanController>
        [HttpPost]
        public bool Create([FromBody] CtHoaDonBan g)
        {
            return db.Create(g);
        }

        // PUT api/<CtHoaDonBanController>/5
        [HttpPut("{id}")]
        public bool Update([FromBody] CtHoaDonBan g)
        {
            return db.Update(g);
        }

        // DELETE api/<CtHoaDonBanController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
