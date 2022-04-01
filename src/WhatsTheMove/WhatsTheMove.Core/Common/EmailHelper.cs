using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WhatsTheMove.Core.Common
{
    public static class EmailHelper
    {
        /// <summary>
        /// Returns standard html body for notifying user of password reset 1-time code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetResetHtml(string code, string username)
        {
            string messageBody = $"<h3>Hello, {username}!</h3>";
            messageBody = messageBody + "<font>See below for your 1-time password reset code: </font><br><br>";
            messageBody = messageBody + $"<font>{code}</font><br><br>";
            messageBody = messageBody + "Thank you for using our application!";

            return messageBody;
        }

        /// <summary>
        /// Returns standard html body for notifying user that their password has been reset
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetResetNotifyHtml(string username)
        {
            string messageBody = $"<h3>Thank you, {username}!</h3>";
            messageBody = messageBody + "<font>Your password was successfully reset.</font><br><br>";
            messageBody = messageBody + "Thank you for using our application!";

            return messageBody;
        }

        /// <summary>
        /// Sends email by simple mail transfer protocol
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="htmlString"></param>
        /// <param name="subject"></param>
        public static void SendEmail(string toAddress, string htmlString, string subject)
        {
            try
            {
                MailAddress from = new MailAddress(DevSupport.DeveloperEmailAddress);
                MailAddress to = new MailAddress(toAddress);
                MailMessage message = new MailMessage(from: from, to: to);
                SmtpClient smtp = new SmtpClient();
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(DevSupport.DeveloperEmailAddress, DevSupport.DeveloperPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);                
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
