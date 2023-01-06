using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnhController : ControllerBase
    {
        lkshopContext db = new lkshopContext();
        [HttpGet("{id}")]
        public AnhSp GetByIdSp(int id)
        {
            return db.AnhSps.Where(x=> x.IdSp== id && x.TrangThai == true).FirstOrDefault();
        }
        [HttpGet("{id}")]
        public List<AnhSp> GetListByIdSp(int id)
        {
            return db.AnhSps.Where(x => x.IdSp == id && x.TrangThai == true).ToList<AnhSp>();
        }
    }
}
