using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LTCReportGen.OperationClass
{
    public class MailSend
    {
        public int SendMail(string attachmentPath)
        {
            int status = 0;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("pmrspathiraja@gmail.com");
                mail.To.Add("pmrspathiraja@gmail.com,buddhikarjt@gmail.com");
                mail.Subject = "Moodle User Account Expire Report From - V3 Software";
                mail.Body = "Please find attached PDF report - This is auto genarated mail from V3-Software";

                System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment("your attachment file");
                attachment = new System.Net.Mail.Attachment(attachmentPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pmrspathiraja", "0035799106534");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                status = 1;

            }
            catch (Exception ex)
            {

                status = 0;
            }

            return status;

            //MessageBox.Show("mail Send");
        }
    }
}
