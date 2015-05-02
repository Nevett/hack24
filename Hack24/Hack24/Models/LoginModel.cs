using System.ComponentModel.DataAnnotations;

namespace Hack24.Models
{
	public class LoginModel
	{
		[EmailAddress]
		public string EmailAddress { get; set; } 

		[Required]
		public string Password { get; set; } 
	}
}