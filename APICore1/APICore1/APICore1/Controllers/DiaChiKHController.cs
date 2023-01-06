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
    public class DiaChiKHController : ControllerBase
    {
        private DiaChiKHBUS db = new DiaChiKHBUS();
        [HttpGet("{id}")]
        public List<DiaChi> GetByIdKH(int id)
        {
            return db.GetByIdKH(id);
        }

        // GET api/<LoaiSanPhamController>/5
        [HttpGet("{id}")]
        public DiaChi Get(int id)
        {
            return db.GetById(id);
        }
        [HttpGet("{id}")]
        // POST api/<LoaiSanPhamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoaiSanPhamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
