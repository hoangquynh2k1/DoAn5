using API_Elec_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.BUS;

namespace API_Elec_Shop.Controllers
{
    public class HomeController : Controller
    {
        private SanPhamBUS db = new SanPhamBUS();
        //[Route("search")]
        //[HttpGet]
        //public IEnumerable<ob> search()
        //{
        //    return db.GetAll();
        //}
        //[Route("SanPham/get-by-id-dong")]
        //[HttpGet]
        //public IEnumerable<Sp> get_sp_by_dong_sp(int id)
        //{
        //    return db.GetByIdDong(id);
        //}
        [Route("SanPham/get-by-id")]
        [HttpGet]
        public object get_sp_by_id(int id)
        {
            return db.GetById(id);
        }
    }
}
