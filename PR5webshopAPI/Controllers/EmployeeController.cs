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
    public class EmployeeController : Controller
    {
        private readonly HelloCoreContext _context;
        public EmployeeController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employee Get(int ID)
        {
            return _context.Employees.Find(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Employee> PostEmployee([FromBody]Employee value)
        {
            _context.Employees.Add(value);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = value.ID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutEmployee(int id, [FromBody]Employee value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var vOldEmployee = _context.Employees.Find(id);

            vOldEmployee.Name = value.Name;
            vOldEmployee.Position = value.Position;
            vOldEmployee.ImgUrl = value.ImgUrl;

            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var vEmployee = _context.Employees.Find(id);

            if (vEmployee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(vEmployee);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
