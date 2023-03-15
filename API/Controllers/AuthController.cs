using API.DTOs.Request;
using API.DTOs.Response;
using API.Services._Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var token = await Task.FromResult(_authService.CreateToken(new List<Claim>() {
                    new Claim ( "UserId", "1")
                }));
            return Ok(token);
        }
    }
}