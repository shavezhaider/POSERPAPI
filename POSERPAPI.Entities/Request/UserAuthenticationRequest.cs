using System;
using MediatR;
using POSERPAPI.Entities.Response;

namespace POSERPAPI.Entities.Request
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class UserAuthenticationRequest :IRequest<UserAuthenticationResponse>
	{

		//
		// TODO: Add constructor logic here
		//
		//[Required(ErrorMessage = "Email is required.")]
		public string UserName { get; set; }
		//[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }

	}
}