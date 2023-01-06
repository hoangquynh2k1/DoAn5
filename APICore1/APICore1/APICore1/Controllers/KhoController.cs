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
    public class KhoController : ControllerBase
    {
        lkshopContext db = new lkshopContext();
        [HttpGet("{id}")]
        public List<Kho> GetListByIdSp(int id)
        {
            return db.Khos.Where(x => x.IdSp == id && x.TrangThai == true).ToList<Kho>();
        }
        [HttpGet("{id}")]
        public Kho Get(int id)
        {
            return db.Khos.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Kho kho = db.Khos.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            if(kho!=null)
            {
                kho.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public bool Back(int id)
        {
            Kho kho = db.Khos.Where(x => x.Id == id && x.TrangThai == false).FirstOrDefault();
            if (kho != null)
            {
                kho.TrangThai = true;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
