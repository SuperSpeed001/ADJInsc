namespace ADJInsc.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ADJInsc.Core.Helper;
   
    using ADJInsc.Core.Service.Interface;
    using ADJInsc.Models.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Configuration;
    using Rotativa.AspNetCore;
    using Wkhtmltopdf.NetCore;

    public class BandejaController : Controller
    {
        public IConfiguration Configuration { get; }
        public string _connectionString { get; set; }
        private readonly IApiService _apiService;
        readonly IGeneratePdf _generatePdf;

        public BandejaController(IConfiguration configuration, IApiService apiService, IGeneratePdf generatePdf)
        {
            Configuration = configuration;
            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _apiService = apiService;

            _generatePdf = generatePdf;
        }
                

        public JsonResult GetLocalidadesList(string departamentoKey)
        {
            var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");

            // var localidades = modelo.LocalidadesList.Where(x => (x.Value.Split('-').ToString()) == departamentoKey);
            var localidades = new List<SelectListItem>();

            foreach (var item in modelo.LocalidadesList)
            {
                // var key = string.Concat(item.Value.Split('-'));
                int position = item.Value.IndexOf("-");
                var key = item.Value.Substring(0, position);
                if (key == departamentoKey)
                {
                    localidades.Add(new SelectListItem
                    {
                        Value = item.Value,
                        Text = item.Text
                    });
                }
            }
            //return Json(localidades);
            return Json(new SelectList(localidades, "Value", "Text"));
        }

        [HttpPost]
        public JsonResult AgregarPersona(string nombre, string dni, string parentescoKey, int modificar, string fechaNac, string disc, string minero, string veterano)
        {
            var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");
            int.TryParse(parentescoKey, out int pKey);
            int.TryParse(disc, out int pDisc);
            int.TryParse(minero, out int pMinero);
            int.TryParse(veterano, out int pVeterano);

            var fecha = DateTime.Parse(fechaNac).ToShortDateString();
            if (int.TryParse(dni, out int _dni))
            {
                var existe = false;
                foreach (var item in modelo.GrupoFamiliar)
                {
                    if (item.InsfNumdoc == _dni)
                    {
                        if (modificar == 0)
                        {
                            existe = true;
                            break;
                        }

                    }
                }
                if (!existe)
                {
                    var pDesc = string.Empty;
                    foreach (var item in modelo.ParentescoList)
                    {
                        if (pKey.ToString() == item.Value)
                        {
                            pDesc = item.Text;
                            break;
                        }
                    }

                    if (modificar == 1)
                    {
                        foreach (var item in modelo.GrupoFamiliar)
                        {
                            if (item.InsfNumdoc == _dni)
                            {
                                modelo.GrupoFamiliar.Remove(item);
                                break;
                            }
                        }
                    }

                    var individuo = new GrupoFamiliarViewModel
                    {
                        InsfNombre = nombre,
                        InsfNumdoc = _dni,
                        ParentescoKey = pKey,
                        ParentescoDesc = pDesc,
                        FechaNacimiento = fecha,
                        InsfDiscapacitado = pDisc,
                        InsfMinero = pMinero,
                        InsfVeterano = pVeterano
                    };
                    modelo.GrupoFamiliar.Add(individuo);

                    HttpContext.Session.SetObjectAsJson<InscViewModel>("viewModelo", modelo);

                    //var modelo = new InscViewModel();   para test
                    return Json(individuo);
                }
                else
                {
                    return Json(modelo);
                }

            }
            else
            {
                return Json(modelo);
            }

        }


        [HttpPost]
        public IActionResult DeletePersona(int id)
        {
            if (int.TryParse(id.ToString(), out int idFamilia))
            {
                var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");
                foreach (var item in modelo.GrupoFamiliar)
                {
                    if (item.InsfNumdoc == id)
                    {
                        modelo.GrupoFamiliar.Remove(item);
                        break;
                    }
                }
                HttpContext.Session.SetObjectAsJson<InscViewModel>("viewModelo", modelo);
                return PartialView("_DatosPartial", modelo);
            }
            else
            {
                return Json("DNI incorrecto.");
            }
        }

        [HttpPost]
        public IActionResult UpdatePersona(int id)
        {
            if (int.TryParse(id.ToString(), out int idFamilia))
            {
                var helper = new InscripcionHelper(_connectionString);
                return Json("ok");
            }
            else
            {
                return Json("No");
            }
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
              //  apellido = "0",
                email = "0",
                tipoFamilia = "0"
            };

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var service = _apiService.PostAsync<ResponseViewModel>("/Insc.Api/login/", "GetLogin", modelOut, null, token).Result;
            if (service.IsSuccess)
            {
                //var modelo = new InscViewModel();
                var modelo = (InscViewModel)service.Result;
                if (modelo.InsNumdoc != null)
                {
                    HttpContext.Session.SetObjectAsJson<InscViewModel>("viewModelo", modelo);
                    //TempData["data"] = modelo;
                    return View("Index", modelo);
                }
                else
                {
                    return RedirectToAction("Inscripcion", "Inscripcion");
                }
             

            }
            else
            {
                return RedirectToAction("Inscripcion", "Inscripcion");
            }

        }

        [HttpPost]
        public IActionResult GetPdfHome()
        {
            var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewModelo");

            return new ViewAsPdf("../Inscripcion/AltaTitular", modelo);

            //return await _generatePdf.GetPdf("Views/Bandeja/Index.cshtml", "Generado");
        }

    }
}
