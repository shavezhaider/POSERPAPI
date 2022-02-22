﻿using POSERPAPI.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Manager.Interface
{
   public interface IEmailSender
    {
        public bool SendEmail(EmailModalRequest emailModal);
    }
}
