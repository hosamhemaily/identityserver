using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Policy = "canupdatedata")]
	public class CoffeeShopController : ControllerBase
	{
        //private readonly ICoffeeShopService coffeeShopService;

		public CoffeeShopController()
		{
			//this.coffeeShopService = coffeeShopService;
		}

		//[HttpGet]
		//public async Task<IActionResult> List()
		//{
		//	var coffeeShops = await coffeeShopService.List();
		//	return Ok(coffeeShops);
		//}	
		
		[HttpGet("list2")]
		//[RequiredScope("Api1.read")]

		public async Task<IActionResult> List2()
		{
			
			return Ok("list2");
		}
	}
}
