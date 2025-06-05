using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomersController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult CustomerList()
        {
            var value = _context.Customers.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCustomers(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Müşteri ekleme işlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCustomers(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return Ok("Müşteri başarıyla silindi");
        }

        [HttpGet("GetCustomer")]
        public ActionResult GetCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateCustomers(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Müşteri güncelleme işlemi başarılı");
        }
    }
}
