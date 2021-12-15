using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movies.domain.service_interface;
using System;
using System.Threading.Tasks;

namespace movies.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _userService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _userService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
