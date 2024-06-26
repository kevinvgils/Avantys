using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using MassTransit;
using CustomerDataService.Domain.Events;
using EventLibrary;
using CustomerDataService.DomainServices.Interfaces;

namespace CustomerDataService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        

        private readonly IBus _IBus;
        private readonly ICustomerService _customerService;

        public CustomerController(IBus bus, ICustomerService customerService)
        {
            _IBus = bus;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerData()
        {
            await _customerService.GetCustomers();
            return Ok();
        }
    }
}
