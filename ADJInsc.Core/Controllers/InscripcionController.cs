namespace ADJInsc.Core.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Helper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ADJInsc.Core.Service.Interface;
    using System;
    using System.Threading;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using ADJInsc.Models.ViewModels;
    using System.Collections.Generic;

    public class InscripcionController : Controller
    {
        public IConfiguration Configuration { get; }
        public string _connectionString { get; set; }
        //private readonly IMailService mailService;
        private readonly IApiService apiAservice;

        public InscripcionController(IConfiguration configuration, IApiService apiAservice)
        {
            Configuration = configuration;
            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];
           // this.mailService = mailService;
            this.apiAservice = apiAservice;
        }
        public IActionResult Inscripcion()
        {
            var model = new UsuarioTitularViewModel();
            var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewTitularModelo");
            if (modelo == null)
            {

            }
            else
            {
                model = modelo;
            }
            //var tokenSource = new CancellationTokenSource();
            //var token = tokenSource.Token;
            //var service = this.apiAservice.GetListAsync<InscViewModel>("/Insc.Api/helper/", "getlistado", token).Result;

            List<SelectListItem> tipoFamilia = model.GetListado().Select
                       (r => new SelectListItem
                       {
                           Value = $"{r.TipoFamiliaKey}",
                           Text = r.TipoFamiliaDesc
                       })
                       .OrderBy(o => o.Text)
                       .ToList();

            model.TipoFamiliaList = tipoFamilia;
            model.Existe = false;   //inicialiso para no mostrar el formulario
            HttpContext.Session.SetObjectAsJson<UsuarioTitularViewModel>("viewTitularModelo", model); //cargo en cache el resultado

            return View("Inscripcion");
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
                    
                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    
                    var service = this.apiAservice.GetAsync<UsuarioTitularViewModel>("/Insc.Api/helper/", "GetInscripto" + "?id=" + numDni, token).Result;  // 

                    var result = (UsuarioTitularViewModel)service.Result;

                    var model = new UsuarioTitularViewModel();

                    result.TipoFamiliaList = model.GetListado().Select
                      (r => new SelectListItem
                      {
                          Value = $"{r.TipoFamiliaKey}",
                          Text = r.TipoFamiliaDesc
                      })
                      .OrderBy(o => o.Text)
                      .ToList();


                    if (result.InsId > 0 )
                    {
                        result.Existe = true;   //porque existe    
                                                // si el estado es E => mostrar login modal
                        if (result.InsEstado == "E")
                        {
                            var model1 = new LoginViewModel
                            {
                                Email = result.InsEmail,
                                Password = "1"
                            };
                            return View("Login", model1);

                            //si el estado es A => esta cargado pero no esta validado
                            // si el estado es E => esta validado
                            // si el estado es nulo => esta migrado y hay que actualizar y no tiene usuario
                            //mostrar para que ingrese con correo contraseña
                            // en utlimo caso si no existe debo cargar el formulario porque es nuevo y InsEstado == "N"

                        }
                        else
                        {
                            if (result.InsEstado == "A")
                            {
                                var model1 = new LoginViewModel
                                {
                                    Email = result.InsEmail,
                                    Password = "2"
                                };
                                return View("Login", model1);
                            }
                            else
                            {
                                if (result.InsEstado == "N")
                                {
                                    var existeT = new UsuarioTitularViewModel();
                                    existeT.TipoFamiliaList = model.GetListado().Select
                     (r => new SelectListItem
                     {
                         Value = $"{r.TipoFamiliaKey}",
                         Text = r.TipoFamiliaDesc
                     })
                     .OrderBy(o => o.Text)
                     .ToList();
                                    existeT.InsNumdoc = numDni;
                                    
                                    existeT.MensajeModel = "Usted está inscripto a un grupo familiar, desea crear un nuevo grupo como Titular? " +
                                        "Si la respuesta es afirmativa ya dejará de pertenecer al grupo familiar de " + result.InsNombre + " con D.N.I.: " + result.InsNumdoc; 
                                    HttpContext.Session.SetObjectAsJson<UsuarioTitularViewModel>("viewTitularModelo", existeT); //cargo en cache el resultado
                                    
                                    ViewBag.Header ="Usted está inscripto a un grupo familiar, desea crear un nuevo grupo como Titular? " +
                                        "Si la respuesta es afirmativa ya dejará de pertenecer al grupo familiar de " + result.InsNombre + " con D.N.I.: " + result.InsNumdoc +
                                         "De lo contrario debe acercarse al I.V.U.Ju.para actualizar sus datos.";
                                    return RedirectToAction("AltaTitular");
                                    // ya existe en base de grupoFamiliar
                                    //se debe mostrar mensaje o un popup que diga que se debe hacercar al ivuj

                                }
                            }
                        }
                    }
                    else
                    {
                        /*
                         * Esto es viejo porque 
                         * if (result.InsId == 0)
                        {
                            return View("ExisteInsc", result);
                            //si insId e menor que cero significa que eldni ya existe en base de grupoFamiliar
                            //se debe mostrar mensaje o un popup que diga que se debe hacercar al ivuj
                        }
                         */
                        result.InsNumdoc = numDni;
                        result.Existe = false;     
                        
                    }
               
                    HttpContext.Session.SetObjectAsJson<UsuarioTitularViewModel>("viewTitularModelo", result); //cargo en cache el resultado
                    ViewBag.Header = string.Empty;
                    return RedirectToAction("AltaTitular");
                    //return View("AltaTitular", result); 
                }
                else
                {
                    return Json("Debe ingresar un número ");
                }
                // TODO: Add update logic here

            }
            catch(Exception ex)
            {
                return View();
            }
        }
        /*
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
        */

        [HttpPost]
        public IActionResult CargarDatos([FromBody] ModeloCarga modeloCarga)
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
                    //si ok => Enviar Email

                    if (modeloResponse.Existe)
                    {
                        if (modeloResponse.InscriptoEnGrupoId > 0)
                        {
                            return Json("Usted Pertenece a un grupo familiar, por favor dirigirse al I.V.U.J. para regularizar su situación.");
                        }
                        if (modeloResponse.UsuarioId > 0)
                        {
                            return Json("El Correo Electrónico ya esta en uso, por favor elija otro!");
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
                                //RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                return Json("El correo ingresa ya esta en uso.");
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

        [HttpPost]
        public IActionResult GoHome()
        {

            return RedirectToAction("Inscripcion");
        }

        
        public IActionResult Login(LoginViewModel model)
        {           
            return View(model);
        }

        public IActionResult AltaTitular()
        {
            var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewTitularModelo");

            if (modelo != null)
            {
                return View(modelo);
            }
            else
            {
                return View(new UsuarioTitularViewModel());
            }
        }

        
        public IActionResult AltaNuevoTitular()
        {
            return LocalRedirect("/Inscripcion/AltaTitular");
        }
    }
}







#region Metodos viejos comentados
/*
[HttpPost]
public async Task<IActionResult> SendMail([FromForm] MailRequest request)
{
    try
    {
        await mailService.SendEmailAsync(request);
        return Ok();
    }
    catch (Exception ex)
    {
        return Json("Operacion no Procesada " + ex.Message.Trim());
    }

}
*/
#endregion

