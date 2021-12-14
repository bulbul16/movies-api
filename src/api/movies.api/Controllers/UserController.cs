using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movies.domain.business_interface;
using System;
using System.Threading.Tasks;

namespace movies.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
