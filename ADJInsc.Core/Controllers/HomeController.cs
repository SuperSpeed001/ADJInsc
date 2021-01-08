namespace ADJInsc.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Helper;
    using ADJInsc.Core.Service.Interface;
    using System;
    using System.Threading;
    using Microsoft.AspNetCore.Authorization;
    using ADJInsc.Models.ViewModels;

    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public string _connectionString { get; set; }
       
        private readonly IApiService apiAservice;

        public HomeController(IConfiguration configuration,  IApiService apiAservice)
        {
            Configuration = configuration;
            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];            
            this.apiAservice = apiAservice;
        }
        public IActionResult Respuesta()
        {

            return View("Respuesta");
        }

        public IActionResult Index()
        {

            InscViewModel model = TempData["data"] as InscViewModel;
            return View(model);


        }

        public IActionResult Existe()
        {
            var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewModelo");
            return View("Existe", modelo);
        }
           
        public IActionResult IndexPanel()
        {
            InscViewModel model = TempData["data"] as InscViewModel;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CargarUsuario([FromBody] ModeloCarga modeloCarga)
        {
/*
            var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewModelo");

            modelo.InsNumdoc = modeloCarga.dni.Trim();
            modelo.InsNombre = modeloCarga.apellido + ", " + modeloCarga.nombre;
            modelo.InsFecins = DateTime.Now.ToShortDateString();
            modelo.InsEmail = modeloCarga.email;
            modelo.Usuario = modeloCarga.usuario;
            modelo.Clave = modeloCarga.clave;
            modelo.InsTipflia = modeloCarga.tipoFamilia;
            */

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var result = this.apiAservice.PostAsync<ResponseViewModel>("/Insc.Api/helper/", "PostModelo", modeloCarga, null, token).Result;  // 


            //aqui van todas las insctrucciones para controlar el valor devuelto
            if (result.IsSuccess)
            {
                var modeloResponse = (ResponseViewModel)result.Result;
                //si ok => Enviar Email
                return Json("Inscripcion realizada con Exito, por favor dirigirse al correo para Validar!");
            }
            else
            {
                return Json("Error");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult BuscarPersona(string numDni)
        {
            try
            {
                var convert = int.TryParse(numDni, out int numeroDniEntero);

                if (convert)
                {
                    //var helper = new InscripcionHelper(_connectionString);

                    var model = new ResponseViewModel();
                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    var service = this.apiAservice.GetAsync<UsuarioTitularViewModel>("/Insc.Api/helper/", "GetInscripto" + "?id=" + numDni, token).Result;  // 

                    var result = (UsuarioTitularViewModel)service.Result;
                    
                    //var inscripto = helper.GetInscripto(numeroDniEntero);

                    //var result = helper.GetListadosInciales().Result;
                    var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewModelo");

                    if (result.InsId > 0)
                    {
                        result.TipoFamiliaList = modelo.TipoFamiliaList;                       

                        HttpContext.Session.SetObjectAsJson<UsuarioTitularViewModel>("viewModelo", result); //cargo en cache el resultado

                        return Json(result);
                    }
                    else
                    {

                        return Json(modelo);
                    }
                    //return Content("NoExiste");
                }
                else
                {
                    return Json("No es un Número Valido " + numDni.Trim());
                }
                // TODO: Add update logic here

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult ValidarDatos(string usuario, string email)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(email))
                {
                    var model = new ModeloCarga
                    {
                        usuario = usuario,
                        email = email
                    };

                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;

                    var service = this.apiAservice.PostAsync<ResponseViewModel>("/Insc.Api/helper/", "GetUsuario", model, null, token).Result;

                    var result = (ResponseViewModel)service.Result;

                    if (result.Existe)
                    {
                        if (result.UsuarioId == 1)
                        {
                            return Json("El Nombre de Usuario ya esta en uso, por favor elija otro!");
                        }
                        else
                        {
                            if (result.InscriptoId == 1)
                            {
                                return Json("El correo ingresado ya esta en uso!");
                            }
                            else
                            {
                                return Json("Disculpe las molestias, vuelva a cargar la página");
                            }
                        }

                    }
                    else
                    {
                        return Json("OK");
                    }
                }
                else
                {
                    return Json("pass");
                }
            }
            catch (Exception ex)
            {
                return Json("Operacion no Procesada " + ex.Message.Trim());
            }
        }

        [HttpPost]
        public IActionResult CargarDatos([FromForm] ModeloCarga modeloCarga)
        {
            try
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;

                var result = this.apiAservice.PostAsync<ResponseViewModel>
                                  ("/Insc.Api/helper/", "PostModelo", modeloCarga, null, token).Result;
               
                if (result.IsSuccess)
                {
                    var modeloResponse = (ResponseViewModel)result.Result;
                    

                    if (modeloResponse.Existe)
                    {
                        if (modeloResponse.UsuarioId == 1)
                        {
                            return Json("El Nombre de Usuario ya esta en uso, por favor elija otro!");
                        }
                        else
                        {
                            if (modeloResponse.InscriptoId == 1)
                            {
                                return Json("El correo ingresado ya esta en uso!");
                            }
                            else
                            {
                                return Json("Disculpe las molestias, vuelva a cargar la página");
                            }
                        }

                    }
                    else
                    {
                        if (modeloResponse.UsuarioId == 0 || modeloResponse.InscriptoId == 0)
                        {
                            return Json("Disculpe las molestias, vuelva a cargar los datos");
                        }
                        else
                        {
                            if (modeloResponse.UsuarioId > 0 && modeloResponse.InscriptoId > 0)
                            {
                                return Json("OK");
                            }
                            else
                            {
                                return Json("Disculpe las molestias, vuelva a cargar los datos");
                            }
                        }                        
                    }
                   
                }
                else
                {
                    return Json("Error");
                }

            }
            catch (Exception ex)
            {
                return Json("Operacion no Procesada " + ex.Message.Trim());
            }
        }
       
       
    }
}
