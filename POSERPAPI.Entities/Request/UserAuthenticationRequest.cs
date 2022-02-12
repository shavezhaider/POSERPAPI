using System;
namespace POSERPAPI.Entities.Request
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class UserAuthenticationRequest 
	{

		//
		// TODO: Add constructor logic here
		//
		//[Required(ErrorMessage = "Email is required.")]
		public string Email { get; set; }
		//[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }

	}
}