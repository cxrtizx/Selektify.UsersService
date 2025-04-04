using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Selektify.UsersService.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;

        // POST: api/Login
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            try
            {
                await _loginService.Login();
                return Ok("Login successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Login failed: {ex.Message}");
            }
        }
    }
}
