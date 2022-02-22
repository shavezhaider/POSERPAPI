using POSERPAPI.Entities.Request;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace POSERPAPI.Manager.Implementation
{
    public class EmailSenderManager : IEmailSender
    {
       
        public bool SendEmail(EmailModalRequest model)
        {
            bool result = true;
            try
            {


                //model.Subject = "testing";
                string emailfrom = ApplicationConstants.SMTP_FROM;

                string Port = ApplicationConstants.SMTP_PORT;
                string Server = ApplicationConstants.SMTP_SERVER;

                string FromPassword = ApplicationConstants.SMTP_FROM;

                int portNum = 0x19;
                if (Port != "")
                {
                    portNum = Convert.ToInt32(Port);
                }
                string replyTo = string.Empty;
                var fromAddress = new MailAddress(emailfrom);
                var toAddress = new MailAddress(model.ToEmailId);
                string fromPassword = ApplicationConstants.SMTP_PASSWORD;

                MailAddress Replyto = null;
                string body = model.Body;
                //if (replyTo != "")
                //{
                //    Replyto = new MailAddress(replyTo);
                //}
                //else
                //{
                Replyto = new MailAddress(model.ToEmailId);
                //}
                MailAddress bcc = null;
                if (!string.IsNullOrEmpty(model.BccEmail))
                {
                    bcc = new MailAddress(ApplicationConstants.Adminemail);
                }

                bool IsHtml = true;
                var smtp = new SmtpClient
                {
                    // Host = "smtp.gmail.com",
                    Host = Server,
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                if (replyTo != "")
                {
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = model.Subject,
                        Body = body,
                        ReplyTo = Replyto

                    })
                    {
                        if (bcc != null)
                            message.Bcc.Add(bcc);
                        message.IsBodyHtml = IsHtml;
                        smtp.Send(message);
                    }
                }
                else
                {
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = model.Subject,
                        Body = body

                    })
                    {
                        if (bcc != null)
                            message.Bcc.Add(bcc);
                        message.IsBodyHtml = IsHtml;
                        smtp.Send(message);

                    }
                }
            }
            catch (Exception ex)
            {
               
                return false;
            }
            
            return result;
        }
    }
}
