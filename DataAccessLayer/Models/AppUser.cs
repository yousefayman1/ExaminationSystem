using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
	public class AppUser
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Username is required.")]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Username must contain only letters.")]
		[StringLength(8, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 8 characters long.")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }
	}
}
