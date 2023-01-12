using System;
namespace JWTAuthentication
{
	public class User
	{
		public string UserName { get; set; } = string.Empty;

		public byte[] ?PassswordHash { get; set; }

		public byte[] ?PasswordSalt { get; set; }
	}
}

