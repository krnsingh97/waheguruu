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
    public class ToysController : ControllerBase
    {
        private ToysshopModel db;

        public ToysController(ToysshopModel db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Toy> Get()
        {
            return db.Toys.OrderBy(a => a.Name).ToList();
        }
    [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Toy toy = db.Toys.Find(id);

            if (toy == null)
            {
                return NotFound();
            }
            return Ok(toy);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Toys.Add(toy);
            db.SaveChanges();
            return CreatedAtAction("Post", toy);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(toy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Toy toy = db.Toys.Find(id);

            if (toy == null)
            {
                return NotFound();
            }
            
            db.Toys.Remove(toy);
            db.SaveChanges();
            return Ok();
        }
    }
}