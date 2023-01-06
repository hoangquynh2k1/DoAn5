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
    public class TaiKhoanKHController : ControllerBase
    {
        private TaiKhoanKHBUS db = new TaiKhoanKHBUS();
        [HttpGet]
        public TaiKhoanKh Login(string username, string password)
        {
            TaiKhoanKh tk = db.Login(username, password);
            return tk;
        }

        // GET api/<LoaiSanPhamController>/5
        [HttpGet("{id}")]
        public TaiKhoanKh Get(int id)
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
