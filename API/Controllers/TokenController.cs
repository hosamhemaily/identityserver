using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		ITokenService _tokenservc;
		public TokenController(ITokenService tokenservice)
		{
			this._tokenservc = tokenservice;
		}

		[HttpPost("{scope}")]
		public async Task<string> Token([Required]string scope)
		{
			var result = await _tokenservc.GetToken(scope);
			return result.AccessToken;
		}


	}
}
