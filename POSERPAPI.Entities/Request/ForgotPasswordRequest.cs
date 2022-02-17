using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Response;

namespace POSERPAPI.Entities.Request
{
    public class ForgotPasswordRequest : IRequest<ForgotPasswordResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
