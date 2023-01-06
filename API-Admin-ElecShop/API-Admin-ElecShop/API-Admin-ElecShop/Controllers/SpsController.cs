using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Admin_ElecShop.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class SpsController : ControllerBase
    {
        SanPhamDAO db = new SanPhamDAO();
        // GET: api/<SpsController>
        [HttpGet]
        public IEnumerable<SanPhamModel> Get()
        {
            return db.Getlist();
        }

        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var dong = formData.Keys.Contains("idDong") ? (formData["idDong"]).ToString() : "0";
                var tenSP = formData.Keys.Contains("tenSp") ? (formData["tenSp"]).ToString().Trim() : "";
                List<SanPhamModel> listFist = db.Getlist();
                List<SanPhamModel> list;
                int idDong = 0;
                if (dong == "0" || dong =="")
                {
                    list = listFist.Where(x => x.TenSp.Contains(tenSP)).OrderBy(x => x.Id).
                        Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                    return Ok(
                         new ResponseListMessage
                         {
                             page = page,
                             totalItem = listFist.Count,
                             pageSize = pageSize,
                             data = list
                         });
                }
                else
                {
                    idDong = int.Parse(dong);
                    list = listFist.Where(x => x.TenSp.Contains(tenSP) && x.IdDong == idDong).OrderBy(x => x.Id).
                        Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                    return Ok(
                         new ResponseListMessage
                         {
                             page = page,
                             totalItem = listFist.Count,
                             pageSize = pageSize,
                             data = list
                         });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/<SpsController>/5
        [HttpGet("{id}")]
        public SanPhamModel Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/<SpsController>
        [HttpPost]
        public bool Create([FromBody] SanPhamModel model)
        {
            return db.Create(model);
        }

        // PUT api/<SpsController>/5
        [HttpPost()]
        public bool Update([FromBody] SanPhamModel model)
        {
                return db.Update(model);
        }

        // DELETE api/<SpsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
