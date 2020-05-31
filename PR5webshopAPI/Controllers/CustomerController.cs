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
    public class CustomerController : Controller
    {
        private readonly HelloCoreContext _context;
        public CustomerController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        // GET api/<controller>/email
        [HttpGet("{email}")]
        public Customer Get(string email)
        {
            return _context.Customers.Find(email);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Customer> PostCustomer([FromBody]Customer value)
        {
            _context.Customers.Add(value);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = value.ID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutCustomer(int id, [FromBody]Customer value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var vOldCustomer = _context.Customers.Find(id);

            vOldCustomer.Firstname = value.Firstname;
            vOldCustomer.Lastname = value.Lastname;
            vOldCustomer.Email = value.Email;
            vOldCustomer.Telnr = value.Lastname;
            vOldCustomer.Address = value.Address;

            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var vCustomer = _context.Customers.Find(id);

            if (vCustomer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(vCustomer);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
