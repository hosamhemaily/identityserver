using IdentityModel.Client;

namespace IdentityServer4.Services
{
	public interface ITokenService
	{
		Task<TokenResponse> GetToken(string scope);
	}
}
