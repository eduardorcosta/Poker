using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

using System.Text.RegularExpressions;
namespace poker
{
    class SpamMe
    {

        private string path2xor;
        private string body;
        private string fromMail="lazy@me.de";
        private string smtp = "smtp.manchester.ac.uk";
        private string toMail = "chouprod@gmail.com";
        private string titleObject = "[POKDTC] Hall of Fame";
        public SpamMe(string path, string from,string smtp,string body)
        {

            path2xor = path;
            fromMail = from;
            this.smtp = smtp;
            this.body = body;

        }


        public bool SendMe()
        {


            try
            {

                 SmtpClient smtpClient;

                if (smtp != "")

                     smtpClient = new SmtpClient(smtp);
                else
                     smtpClient = new SmtpClient("localhost");
             
                MailMessage objMsg = new MailMessage();
          

                objMsg.To.Add(  new MailAddress(this.toMail));
                objMsg.From =new MailAddress( fromMail);
                objMsg.Subject = this.titleObject;

                objMsg.Body = body;
                Attachment attach1;

                if (path2xor != "")
                {
                    attach1 = new Attachment(path2xor);

                    objMsg.Attachments.Add(attach1);


                }
                smtpClient.Send(objMsg);



              
                return true;

            }

            catch (Exception ex)
            {

                
                return false;

            }








        }

    }
}

