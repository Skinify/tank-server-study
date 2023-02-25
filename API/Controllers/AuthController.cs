using API.DTOs.Request;
using API.DTOs.Response;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AuthService _authService;

        public AuthController(ILogger<AuthController> logger, AuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost(Name = "Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            if (loginRequestDTO.Login == "admin" && loginRequestDTO.Password == "admin")
                return Ok(_authService.CreateToken(new List<Claim>() {
                    new Claim ( "http://example.org/claims/simplecustomclaim", "Driver's License")
                }));

            return Ok(null);
        }
    }
}