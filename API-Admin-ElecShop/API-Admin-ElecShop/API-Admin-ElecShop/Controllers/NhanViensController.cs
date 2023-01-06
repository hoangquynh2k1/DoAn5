using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Services;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Services;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;
using Microsoft.AspNetCore.Authorization;
using API_Admin_ElecShop.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Admin_ElecShop.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private IUserService _userService;
        lkshopContext db = new lkshopContext();
        
        // GET: api/<NhanViensController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public NhanViensController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {

            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu sai!" });

            return Ok(user);
        }
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var hoten = formData.Keys.Contains("hoten") ? (formData["hoten"]).ToString().Trim() : "";
                var result = from t in db.NhanViens
                             select new { t.Id,t.HoTen,t.GioiTinh,t.NgaySinh,t.ChucVu,t.Sdt };
                var kq = result.Where(x => x.HoTen.Contains(hoten)).OrderByDescending(x => x.Id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                return Ok(
                         new ResponseListMessage
                         {
                             page = page,
                             totalItem = kq.Count,
                             pageSize = pageSize,
                             data = kq
                         });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // GET api/<NhanViensController>/5
        [HttpGet("{id}")]
        public NhanVien Get(int id)
        {
            return db.NhanViens.Where(x=>x.Id==id).FirstOrDefault();
        }

        // POST api/<NhanViensController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NhanViensController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NhanViensController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
