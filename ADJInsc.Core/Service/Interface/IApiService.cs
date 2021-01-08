namespace ADJInsc.Core.Service.Interface
{
    using ADJInsc.Models.Basic;
    using ADJInsc.Models.ViewModels;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IApiService
    {        
        public Task<Response> GetAsync<T>(string prefix, string controller, CancellationToken cancellationToken);
        public Task<Response> PostAsync<T>(string prefix, string controller, ModeloCarga modelo, InscViewModel inscViewModel, CancellationToken cancellationToken);
    }
}
