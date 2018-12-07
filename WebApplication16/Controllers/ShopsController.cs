using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private ToysshopModel db;

        public ShopsController(ToysshopModel db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Shop> Get()
        {
            return db.Shops.OrderBy(a => a.Name).ToList();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Shop shop = db.Shops.Find(id);

            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shops.Add(shop);
            db.SaveChanges();
            return CreatedAtAction("Post", shop);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(shop).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Shop shop = db.Shops.Find(id);

            if (shop == null)
            {
                return NotFound();
            }

            db.Shops.Remove(shop);
            db.SaveChanges();
            return Ok();
        }
    }
}