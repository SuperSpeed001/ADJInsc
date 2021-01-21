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

        [HttpPost]
        public ActionResult Index(string inputUserName, string inputPassword)
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
        public JsonResult AgregarPersona(string nombre, string dni, string parentescoKey, string fechaNac, string disc, string minero, string veterano)
        {
            var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");
            int.TryParse(parentescoKey, out int pKey);
            int.TryParse(disc, out int pDisc);
            int.TryParse(minero, out int pMinero);
            int.TryParse(veterano, out int pVeterano);


            if (!DateTime.TryParse(fechaNac, out DateTime fecha)) return Json(modelo);

            if (!int.TryParse(dni, out int _dni)) return Json(modelo);

            var pDesc = string.Empty;
            foreach (var item in modelo.ParentescoList)
            {
                if (pKey.ToString() == item.Value)
                {
                    pDesc = item.Text;
                    break;
                }
            }

            var existe = false;

            foreach (var item in modelo.GrupoFamiliar)
            {
                if (item.InsfNumdoc == _dni)
                {
                    item.InsfNombre = nombre;
                    item.InsfNumdoc = _dni;
                    item.ParentescoKey = pKey;
                    item.ParentescoDesc = pDesc;
                    item.FechaNacimiento = fecha;
                    item.InsfDiscapacitado = pDisc;
                    item.InsfMinero = pMinero;
                    item.InsfVeterano = pVeterano;

                    existe = true;
                    break;
                }
            }

            if (!existe)
            {

                foreach (var item in modelo.GrupoFamiliar)
                {
                    if (item.InsfNumdoc == _dni)
                    {
                        modelo.GrupoFamiliar.Remove(item);
                        break;
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
                
        public JsonResult UpdatePersona(int ID)
        {
            if (int.TryParse(ID.ToString(), out int dni))
            {
                var modelo = HttpContext.Session.GetObjectFromJson<UsuarioTitularViewModel>("viewModelo");
                var individuo = new GrupoFamiliarViewModel();
                foreach (var item in modelo.GrupoFamiliar)
                {
                    if (item.InsfNumdoc == dni)
                    {
                        individuo = item;
                        break;
                    }
                }
               
                return Json(individuo);
            }
            else
            {
                return Json("No");
            }
        }
        
       
        public IActionResult GetPdfHome()
        {
            var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");

            //return new ViewAsPdf("_Reporte.cshtml", modelo);
            return new ViewAsPdf("_Reporte", modelo);
            
        }

        

        public JsonResult List()
        {
            var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");
            if (modelo == null)
            {
                return Json(null);
            }
            return Json(modelo.GrupoFamiliar);
        }
               
        public IActionResult GuardarData1(InscViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var modelo1 = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");

                modelo1 = modelo;

                HttpContext.Session.SetObjectAsJson<InscViewModel>("viewModelo", modelo1);
            }
            return View();
        }
        public JsonResult GuardarData(string dni, string nombre, string tipoFamilia, int disc,int minero, int veterano, string cuitUno, string cuitTres,
                                      string direccion, string departamento,string localidad, string lugarTrabajo, string revista, string neto, string telefono)
        {
            var modelo = HttpContext.Session.GetObjectFromJson<InscViewModel>("viewModelo");

            var keyLoc = localidad.Split("-");
            var desKeyLoc = string.Empty;
            var desKeyDep = string.Empty;
            
            foreach (var item in modelo.LocalidadesList)
            {
                if (localidad == item.Value.ToString())
                {
                    desKeyLoc = item.Text.Trim();
                    break;
                }
            }

            foreach (var item in modelo.DepartamentosList)
            {
                if (departamento == item.Value)
                {
                    desKeyDep = item.Text.Trim();
                    break;
                }
            }

            modelo.InsNumdoc = dni;
            modelo.InsNombre = nombre;
            modelo.IdTipoFamilia = int.Parse(tipoFamilia);
            modelo.InsDiscapacitado = disc;
            modelo.InsMinero = minero;
            modelo.InsVeterano = veterano;
            modelo.CuitCuil = cuitUno + "-" + dni + '-' + cuitTres;
            modelo.Direccion = direccion;
            modelo.DepartamentoKey = int.Parse(departamento);
            modelo.DepartamentoDesc = desKeyDep;
            modelo.LocalidadKey = int.Parse(keyLoc[1]);  //1-12  ES EL 12
            modelo.LocalidadDesc = desKeyLoc;
            modelo.NombreEmpleo = lugarTrabajo;
            modelo.TipoRevistaKey = int.Parse(revista);
            modelo.IngresoNeto = neto;
            modelo.InsTelef = telefono;

            HttpContext.Session.SetObjectAsJson<InscViewModel>("viewModelo", modelo);

            /* var redirectUrl1 = Url.Action("GetPdfHome", "Bandeja");

               para test
            return Json(new
            {
                redirectUrl = redirectUrl1,
                isRedirect = true
            });
            */
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var service = this._apiService.PostAsync<ResponseViewModel>("/Insc.Api/helper/", "PostInscViewModel", null, modelo, token).Result;

            if (service.IsSuccess)
            {
                var respuesta = (ResponseViewModel)service.Result;

                if (respuesta.Existe)
                {
                    var redirectUrl1 = Url.Action("GetPdfHome", "Bandeja");

                    return Json(new
                    {
                        redirectUrl = redirectUrl1,
                        isRedirect = true
                    });
                }
                else
                {
                    
                    return Json(new
                    {
                        redirectUrl = "",
                        isRedirect = false
                    });
                }
            }

            
            else
            {
                return Json(new
                {
                    redirectUrl = "",
                    isRedirect = false
                });
            }
            

            
            if (service.IsSuccess)
            {
                var result = (UsuarioTitularViewModel)service.Result;
                return Json(new
                {
                    redirectUrl = Url.Action("GetPdfHome", "Bandeja"),
                    isRedirect = true
                });
                //return JsonResult("GetPdfHome", "../Bandeja/_Reporte.cshtml", result);
            }

        }
    }
}
