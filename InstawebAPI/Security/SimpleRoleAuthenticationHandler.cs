using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace InstawebAPI.Security
{
    public class SimpleRoleAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public SimpleRoleAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var role = "Client";

            if (Request.Headers.TryGetValue("X-Role", out var headerRole) && !string.IsNullOrWhiteSpace(headerRole))
            {
                role = headerRole.ToString();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "demo-user"),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
