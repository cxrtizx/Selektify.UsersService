using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Stores;
using SpotifyAPI.Web;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BusinessLogicLayer.Services
{
    public class LoginService(IVerifierStore verifierStore) : ILoginService
    {
        private readonly IVerifierStore _verifierStore = verifierStore;

        public Task Login()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            var state = Guid.NewGuid().ToString();
            _verifierStore.StoreVerifier(state, verifier);

            var loginRequest = new LoginRequest(
                new Uri("http://localhost:3001/api/login/callback"),
                "e35e4e5b07854970bb1f944055f0643e",
                LoginRequest.ResponseType.Code)
            {
                State = state,
                CodeChallengeMethod = "S256",
                CodeChallenge = challenge,
                Scope = [Scopes.PlaylistReadPrivate, Scopes.UserReadEmail]
            };

            var uri = loginRequest.ToUri();
            OpenBrowser(uri.AbsoluteUri);

            return Task.CompletedTask;
        }

        private static void OpenBrowser(string url)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Failed to open browser: {ex.Message}", ex);
            }
        }
    }
}
