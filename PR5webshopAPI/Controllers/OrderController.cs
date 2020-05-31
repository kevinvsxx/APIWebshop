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
    public class OrderController : Controller
    {
        private readonly HelloCoreContext _context;
        public OrderController(HelloCoreContext context)
        {
            _context = context;
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Order> PostOrder([FromBody]Order value)
        {
            _context.Orders.Add(value);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = value.ID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutOrder(int id, [FromBody]Order value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var vOldOrder = _context.Orders.Find(id);

            vOldOrder.CustomerID = value.CustomerID;
            vOldOrder.Orderdate = value.Orderdate;

            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var vOrder = _context.Orders.Find(id);

            if (vOrder == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(vOrder);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
