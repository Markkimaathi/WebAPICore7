using APIDEV.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace APIDEV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
                var data =await this.service.Getall();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
        }
    }
}
