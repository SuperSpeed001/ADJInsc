namespace ADJInsc.Web.Controllers
{
    using ADJInsc.Models.Model.DBInsc;
    using ADJInsc.Web.Helper;
    using ADJInsc.Web.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class InscripcionController : Controller
    {
        public List<InsFamilia> _gruopFamiliar { get { return new List<InsFamilia>(); } }
        public InscViewModel ModeloFamilia { get; set; }

        // GET: Inscripcion
        public ActionResult Index()
        {
            //vvar helper = new SolicitarTurnoAuxiliar();

            var result = new InscViewModel();
            //result.GrupoFamiliar = new List<InsFamilia>();
            return View(result);
        }

        // POST: Inscripcion/Edit/5
        [HttpPost]
        public ActionResult BuscarPersona(string numDni)
        {
            try
            {
                var convert = int.TryParse(numDni, out int numeroDniEntero);

                if (convert)
                {
                    var helper = new InscripcionHelper();
                    ModeloFamilia = new InscViewModel();
                    var result = helper.GetInscripto(numeroDniEntero);

                    if (result.InsId > 0)
                    {
                        return PartialView("_DatosPartial", result);
                    }
                    else
                    {
                        return PartialView("_DatosPartial", result);
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
        public ActionResult AgregarPersona(string nombre, string apellido, string dni)
        {
            int.TryParse(dni, out int _dni);           
           

            var modelo = (InscViewModel)System.Web.HttpContext.Current.Session["viewModelo"];
            modelo.GrupoFamiliar.Add(new InsFamilia
            {
                InsfNombre = nombre + " " + apellido,
                InsfNumdoc = _dni
            });
            System.Web.HttpContext.Current.Session["viewModelo"] = modelo;
            return PartialView("_DatosPartial", modelo);
        }

        [HttpPost]
        public ActionResult AgregarTitular(InscViewModel inscViewModel)           //(string nombre, string apellido, string dni, string email)
        {
            int.TryParse(inscViewModel.DniVM, out int dni);
            
            //int.TryParse(dni, out int _dni);

            /*ModeloFamilia = new InscViewModel
            {
                InsNombre = nombre + " " + apellido,
                InsNumdoc = _dni.ToString(),
                InsEmail = email,
                NombreVM = nombre,
                ApellidoVM = apellido
            };
            */
            System.Web.HttpContext.Current.Session["viewModelo"] = ModeloFamilia;
            return PartialView("_DatosPartial", ModeloFamilia);
        }

    }
}
