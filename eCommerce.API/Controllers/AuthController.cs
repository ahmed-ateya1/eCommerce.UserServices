using eCommerce.Core.Dtos;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest("request is null");
            }
            var response = await _userService.Register(request);
            if (response == null || !response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if(request == null)
            {
                return BadRequest("request is null");
            }
            var response = await _userService.Login(request);
            if (response == null || !response.Success)
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }
        
    }
}
