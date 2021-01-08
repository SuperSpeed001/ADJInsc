namespace ADJInsc.Core.Logica.Service.Interface
{
    using ADJInsc.Core.Logica.Service.Settings;
    using System.Threading.Tasks;

    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
