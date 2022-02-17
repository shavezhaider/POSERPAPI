using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Response;
using POSERPAPI.Entities.Request;

namespace POSERPAPI.Manager.Command.Account
{
    public class ForgotPasswordCommand : IRequest<ForgotPasswordResponse>
    {
        public ForgotPasswordRequest passwordRequest;
        public ForgotPasswordCommand(ForgotPasswordRequest forgotPasswordRequest)
        {
            passwordRequest = forgotPasswordRequest;
        }
    }
}
