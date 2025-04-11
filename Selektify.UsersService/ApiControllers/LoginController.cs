using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Stores;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace Selektify.UsersService.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginService loginService, IVerifierStore verifierStore) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;
        private readonly IVerifierStore _verifierStore = verifierStore;

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

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code, [FromQuery] string state)
        {
            var initialResponse = await new OAuthClient().RequestToken(
                new PKCETokenRequest("e35e4e5b07854970bb1f944055f0643e", code, new Uri("http://localhost:3001/api/login/callback"), _verifierStore.GetVerifier(state)));

            var spotify = new SpotifyClient(initialResponse.AccessToken);
            var authenticator = new PKCEAuthenticator("e35e4e5b07854970bb1f944055f0643e", initialResponse);

            var config = SpotifyClientConfig.CreateDefault()
              .WithAuthenticator(authenticator);
            //var spotify = new SpotifyClient(config);
            return Ok("Callback received");
        }
    }
}

