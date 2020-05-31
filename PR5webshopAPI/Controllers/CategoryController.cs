using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PR5webshopAPI.Data;
using PR5webshopAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PR5webshopAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly HelloCoreContext _context;
        public CategoryController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Category> PostCategory([FromBody]Category value)
        {
            _context.Categories.Add(value);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = value.ID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutCategory(int id, [FromBody]Category value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var vOldCategory = _context.Categories.Find(id);

            vOldCategory.Name = value.Name;
            vOldCategory.ImgUrl = value.ImgUrl;

            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var vCategory = _context.Categories.Find(id);

            if (vCategory == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(vCategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
