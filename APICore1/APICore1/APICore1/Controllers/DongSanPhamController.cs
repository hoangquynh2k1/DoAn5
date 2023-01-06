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
    public class DongSanPhamController : ControllerBase
    {
        private DongSanPhamBUS db = new DongSanPhamBUS();
        // GET: api/<DongSanPhamController>
        [HttpGet]
        public IEnumerable<DongSp> Get()
        {
            var data = db.GetAll();
            return data;
        }

        // GET api/<DongSanPhamController>/5
        [HttpGet("{id}")]
        public DongSp Get(int id)
        {
            return db.GetById(id);
        }
        [HttpGet("{id}")]
        public List<DongSp> GetByIdLoai(int id)
        {
            return db.GetByIdLoai(id);
        }
        // POST api/<DongSanPhamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DongSanPhamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DongSanPhamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
