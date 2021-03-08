namespace ADJInsc.Core.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using ADJInsc.Core.Api.Service.Interface;
    using ADJInsc.Models.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Configuration;
    using ADJInsc.Core.Api.Service.Inscripcion;

    [ApiController]
    [Route("[controller]")]
    public class HelperController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public string _connectionString { get; set; }
       // private readonly IMailService mailService;
        private readonly InscripcionService service;

        public HelperController(IConfiguration configuration, IMailService mailService)
        {
            Configuration = configuration;
            _connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //this.mailService = mailService;

            service = new InscripcionService(_connectionString, mailService);
        }
        // GET: api/<HelperController>
                
        [HttpGet("/helper/GetListado")]
        public async Task<InscViewModel> GetListado()
        {
            //var helper = new InscripcionService(_connectionString, mailService);
            var result = service.GetListadosInciales().Result;
            var model = new InscViewModel();

            var tipoFamilia = result.TipoFamiliaList.Select
                        (r => new SelectListItem
                        {
                            Value = $"{r.TipoFamiliaKey}",
                            Text = r.TipoFamiliaDesc
                        })
                        .OrderBy(o => o.Text)
                        .ToList();

            var departamento = result.DepartamentosList.Select
               (r => new SelectListItem
               {
                   Value = $"{r.DepartamentoKey}",
                   Text = r.DepartamentoDesc
               })
               .OrderBy(o => o.Text)
               .ToList();

            var localidad = result.LocalidadList.Select
                   (r => new SelectListItem
                   {
                       Value = $"{r.DepartamentoKey + "-" + r.LocalidadKey}",
                       Text = r.LocalidadDesc
                   })
                   .OrderBy(o => o.Text)
                   .ToList();

            var parentesco = result.ParentescoList.Select(r => new SelectListItem
            {
                Value = $"{r.ParentescoKey}",
                Text = r.ParentescoDesc
            }).OrderBy(o => o.Text).ToList();

            model.DepartamentosList = departamento;
            model.LocalidadesList = localidad;
            model.TipoFamiliaList = tipoFamilia;
            model.ParentescoList = parentesco;

            await Task.Delay(100).ConfigureAwait(false);
            return model;
        }
              

        // POST api/<HelperController>
        [HttpPost("/helper/PostModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseViewModel>> PostModelo(ModeloCarga modeloCarga)
        {
            // var helper = new InscripcionService(_connectionString, mailService);
            var modelo = service.PostServerModelo(modeloCarga).Result;

            if (modelo.UsuarioId < 0)   
                return BadRequest();
            
            await Task.Delay(100).ConfigureAwait(false);
            return modelo;
        }

        // POST api/<HelperController>
        [HttpPost("/helper/PostInscViewModel")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseViewModel>> PostInscViewModel(InscViewModel inscViewModel)
        {
            // var helper = new InscripcionService(_connectionString, mailService);
            var modelo = service.PostInscViewModel(inscViewModel).Result;

            if (modelo.UsuarioId < 0)
                return BadRequest();

            await Task.Delay(100).ConfigureAwait(false);
            return modelo;
        }


        [HttpGet("/helper/GetInscripto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UsuarioTitularViewModel> GetInscripto(int id)
        {
            //var helper = new InscripcionService(_connectionString, mailService);
            var model = service.GetInscripto(id).Result;

            await Task.Delay(100).ConfigureAwait(false);
            return model;

        }


    }
}
