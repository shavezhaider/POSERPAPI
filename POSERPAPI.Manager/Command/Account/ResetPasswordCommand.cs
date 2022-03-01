using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;

namespace POSERPAPI.Manager.Command.Account
{
   public class ResetPasswordCommand : IRequest<ProcessingStatusEntity>
    {
        public ResetPasswordRequest resetPassword;
        public ResetPasswordCommand(ResetPasswordRequest resetPasswordRequest)
        {
            resetPassword = resetPasswordRequest;
        }
    }
}
