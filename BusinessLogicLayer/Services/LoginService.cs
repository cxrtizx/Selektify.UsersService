using BusinessLogicLayer.ServiceContracts;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LoginService : ILoginService
    {
        public Task Login()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            var loginRequest = new LoginRequest(new Uri("http://localhost:3001"), "e35e4e5b07854970bb1f944055f0643e", LoginRequest.ResponseType.Code)
            {
                CodeChallengeMethod = "S256",
                CodeChallenge = challenge,
                Scope = [Scopes.PlaylistReadPrivate, Scopes.UserReadEmail]
            };
            var uri = loginRequest.ToUri();

            return Task.CompletedTask;

            //var initialResponse = new OAuthClient().RequestToken(new PKCETokenRequest("ClientId", code, new Uri("http://localhost:3001"), verifier));

            //var spotify = new SpotifyClient(initialResponse.Result.AccessToken);
        }


        //public async Task GetCallback(string code)
        //{
        //    var initialResponse = await new OAuthClient().RequestToken(new PKCETokenRequest("ClientId", code, new Uri("http://localhost:3001"), verifier));

        //    var spotify = new SpotifyClient(initialResponse.AccessToken);
        //}
    }
}
