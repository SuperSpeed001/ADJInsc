namespace ADJInsc.Core.Api
{
    using System.Threading;
    using ADJInsc.Core.Service.Interface;
    using ADJInsc.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class VerificadorController : ControllerBase
    {
        private readonly IApiService _apiAservice;
        public VerificadorController(IApiService apiAservice)
        {
            _apiAservice = apiAservice;
        }

        // GET: api/<VerificadorController>
        [HttpGet("{id}")]        
        public IActionResult GetHome(string id)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            
            var service = _apiAservice.GetAsync<ResponseViewModel>("/Insc.Api/login/", "GetVerificador" + "?id=" + id, token).Result;  // 

            var response = (ResponseViewModel)service.Result;

            if (!response.Existe)   return RedirectToAction("Inscripcion", "Inscripcion");
            
           
            return RedirectToAction("Respuesta", "Home");
        }
           
    }
}
