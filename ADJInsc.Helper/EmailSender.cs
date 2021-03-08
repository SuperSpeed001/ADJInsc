using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ADJInsc.Helper
{
   

    public class EmailSender
    {
        public string codigo { get; set; }
        public string Email { get; set; }
        public EmailSender(string CodigoVerificador, string email)
        {
            codigo = CodigoVerificador;
            Email = email;
        }


        /*
         
         Dim client As SmtpClient = New SmtpClient("mail.ivuj.gob.ar")
With client
            .UseDefaultCredentials = True
            .Credentials = New NetworkCredential("computos@ivuj.gob.ar", "ivuj2021")
            .EnableSsl = False
            .Port = 587
End With*/
        public Task<bool> SendEmail()
        {
            try
            {
                //http://localhost:49999/api/verificador/9809jsijd89a7sekjnpdf
                var url = "<a href=http://190.52.39.140/insc/Api/Verificador/" + codigo + " > Validar </a>";
                var request = new MailRequest
                {
                    ToEmail = Email,
                    Subject = "Instituto de Vivienda y Urbanismo de Jujuy",
                    Body = string.Format("Haga clic en el siguiente enlace para validar sus datos {0} ", url)//,
                    //Attachments = null
                };

                MailMessage message = new MailMessage("info_inscripcion@ivuj.gob.ar",Email,request.Subject,request.Body);
                var result = SendEmailAsync(message);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task<bool> SendEmailAsync(MailMessage mailRequest)
        {
            try
            {
                using(SmtpClient smtp = new SmtpClient("mail.ivuj.gob.ar"))
                {
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential("info_inscripcion@ivuj.gob.ar", "iYd_HF@7zKuc");
                    smtp.EnableSsl = false;
                    smtp.Port = 587;

                    await smtp.SendMailAsync(mailRequest);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
