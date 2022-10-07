using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Quickstart.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenServ;

        public TokenController(ITokenService tokenServ)
        {
            _tokenServ = tokenServ;
        }

        [HttpGet()]
        public async Task<IActionResult> gettoken()
        {
            var result = await _tokenServ.GetToken("CoffeeAPI.read");
            return Ok( new TokenResponse { token = result.AccessToken});
        }
    }
}
