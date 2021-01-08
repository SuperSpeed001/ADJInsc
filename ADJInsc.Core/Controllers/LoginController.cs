namespace ADJInsc.Core.Controllers
{    
    using System.Threading;
    using ADJInsc.Core.Service.Interface;
    using ADJInsc.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class LoginController : Controller
    {
        public IConfiguration Configuration { get; }
        public string _connectionString { get; set; }
        //private readonly IMailService mailService;
        private readonly IApiService _apiService;

        public LoginController(IConfiguration configuration, IApiService apiAservice)
        {
            Configuration = configuration;
            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            // this.mailService = mailService;
            _apiService = apiAservice;
        }
               
        [HttpPost]
        public ActionResult Login(string inputUserName, string inputPassword)
        {
            var modelOut = new ModeloCarga
            {
                usuario = inputUserName,
                clave = inputPassword,
                dni = "0",
                nombre = "0",
                //apellido = "0",
                email = "0",
                tipoFamilia = "0"
            };

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            
            var service = _apiService.PostAsync<ResponseViewModel>("/Insc.Api/login/", "GetLogin", modelOut, null, token).Result;
            if (service.IsSuccess)
            {
                var modelo = (InscViewModel)service.Result;
                TempData["data"] = modelo;
                return View();
               
            }
            else
            {
                return View();
            }
            
        }

        // GET api/<VerificadorController>/5
        [HttpGet("{email}")]
        public IActionResult GetReset(string email)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var service = _apiService.GetAsync<bool>("/Insc.Api/api/Login/", "GetResetPasword" + "?email=" + email, token).Result;  // 

            if (!service.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Respuesta", "Home");
        }
    }
}
