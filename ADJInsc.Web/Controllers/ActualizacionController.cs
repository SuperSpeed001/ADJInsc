namespace ADJInsc.Web.Controllers
{
    using ADJInsc.Models.Model;
    using ADJInsc.Web.Helper;
    using ADJInsc.Web.Models;
    using System.Web.Mvc;

    public class ActualizacionController : Controller
    {
        // GET: Actualizacion
        public ActionResult Index()
        {
            var helper = new SolicitarTurnoAuxiliar();
            var result = helper.InicializarModelo();
            return View(result);
        }

        [Route("/Actualizacion/GetPersonas")]
        [HttpPost]
        public ActionResult GetPersonas()
        {
            //string path = Path.Combine(_env.ContentRootPath, "\\wwwroot\\images\\Local");
            SolicitarTurnoAuxiliar auxiliar = new SolicitarTurnoAuxiliar();
            var result = auxiliar.InicializarModelo();
            result.GrupoFamiliar.Add(new GrupoFamiliarViewModel
            {
                PersonaNombre = "Patricia Julieta",
                PersonaApellido = "Apaza",
                PersonaDni = "26130986"
            });
            result.GrupoFamiliar.Add(new GrupoFamiliarViewModel
            {
                PersonaNombre = "Maximo Mateo",
                PersonaApellido = "Gonzalez",
                PersonaDni = "56856211"
            });


            return PartialView("_DatosPartial", result.GrupoFamiliar);
        }

        [Route("/Actualizacion/CreateAjax")]
        [HttpPost]
        public ActionResult CreateAjax()
        {
            return Json("Error, no se pudo guardar los datos, revise los datos ingresados");
        }


    }
}
