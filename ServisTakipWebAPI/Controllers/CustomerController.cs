using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Services;

namespace ServisTakipWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService? customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customers = _customerService.GetCustomerById(id);
            return Ok(customers);
        }

        [HttpPost("create")]
        public IActionResult CreateCustomer([FromBody] CustomerRequestModel customer)
        {
            _customerService.CreateCustomer(customer);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateCustomer([FromBody] CustomerRequestModel customer,int id)
        {
            _customerService.UpdateCustomer(id,customer);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCustomer(int id) 
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
