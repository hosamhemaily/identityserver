﻿namespace API2.Services
{
	public class IdentityServerSettings
	{
		public string DiscoveryUrl { get; set; }
		public string ClientName { get; set; }
		public string ClientPassword { get; set; }
		public bool UseHttps { get; set; }
		public string GrantType { get; set; }
	}
}
