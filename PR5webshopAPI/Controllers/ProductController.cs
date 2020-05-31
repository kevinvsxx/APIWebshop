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
    public class ProductController : Controller
    {
        private readonly HelloCoreContext _context;
        public ProductController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Product> PostProduct([FromBody]Product value)
        {
            _context.Products.Add(value);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = value.ID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutProduct(int id, [FromBody]Product value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var vOldProduct = _context.Products.Find(id);

            vOldProduct.Name = value.Name;
            vOldProduct.CategoryID = value.CategoryID;
            vOldProduct.ImgUrl = value.ImgUrl;
            vOldProduct.Price = value.Price;

            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var vProduct = _context.Products.Find(id);

            if (vProduct == null)
            {
                return NotFound();
            }

            _context.Products.Remove(vProduct);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
