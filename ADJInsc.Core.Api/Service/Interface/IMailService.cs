namespace ADJInsc.Core.Api.Service.Interface
{
    using ADJInsc.Core.Api.Service.Settings;
    using System.Threading.Tasks;

    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
