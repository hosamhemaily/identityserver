using API2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TestApi2Controller> _logger;
        private readonly ITokenService _tokenservc;

        public TokenController(ILogger<TestApi2Controller> logger, ITokenService tokenservc)
        {
            _logger = logger;
            _tokenservc = tokenservc;
        }

        [HttpPost("{scope}")]
        public async Task<string> Token(string scope)
        {
            var result = await _tokenservc.GetToken(scope);
            return result.AccessToken;
        }
    }
}