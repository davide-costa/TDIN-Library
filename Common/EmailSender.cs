using System;
using System.Net;
using System.Net.Mail;

namespace Common
{
    public class EmailSender
    {
        private static string _emailAddress = "librarytdin@gmail.com";
        private static MailAddress _emailAddressObject = new MailAddress(_emailAddress, "Library TDIN");
        private static string _password = "newbooks4u";

        public static void SendEmail(string body, string subject, string destinationEmailAddress,
            string destinationName)
        {
            try
            {
                MailAddress destinationAddressObject = new MailAddress(destinationEmailAddress, destinationName);
                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                    System.Net.NetworkCredential(_emailAddress, _password);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                MailMessage myMail = new System.Net.Mail.MailMessage(_emailAddressObject, destinationAddressObject);

                // set subject and encoding
                myMail.Subject = subject;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = body;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;

                // text or html
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(myMail);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error sending email!");
                return;
            }
         
        }
    }

}


