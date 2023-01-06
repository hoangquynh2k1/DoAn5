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
    public class GiaController : ControllerBase
    {
        lkshopContext db = new lkshopContext();
        [HttpGet("{id}")]
        public Gium GetByIdSp(int id)
        {
            return db.Gia.Where(x=> x.IdSp== id && x.TrangThai == true).FirstOrDefault();
        }
    }
}
