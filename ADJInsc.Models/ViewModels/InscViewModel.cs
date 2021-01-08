namespace ADJInsc.Models.ViewModels
{
    using ADJInsc.Models.Models.DBInsc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InscViewModel: Inscriptos
    {
        public InscViewModel()
        {
           GrupoFamiliar = new List<GrupoFamiliarViewModel>();
        }
        
        public int DepartamentoKey { get; set; }
        public string DepartamentoDesc { get; set; }
        
        public int LocalidadKey { get; set; }
        public string LocalidadDesc { get; set; }

        public int ParentescoKey { get; set; }
        public string ParentescoDesc { get; set; }

        public int InsFFamiliaKey { get; set; }
        public IList<GrupoFamiliarViewModel> GrupoFamiliar { get; set; }

        [Required]
        public string NombreVM { get; set; }

        [Required]
        public string ApellidoVM { get; set; }

        [Required]
        public string DniVM { get; set; }

        public string Usuario { get; set; }
        public string Clave { get; set; }

        public string Direccion { get; set; }
        public string Barrio { get; set; }

        public int TipoEmpleoKey { get; set; }
        public int TipoRevistaKey { get; set; }

        public string CuitUno { get; set; }
        public string CuitTres { get; set; }

        public int Minero { get; set; }
        public int Veterano { get; set; }
        public int Discapacitado { get; set; }

        public IEnumerable<SelectListItem> TipoFamiliaList { get; set; }
        public IEnumerable<SelectListItem> LocalidadesList { get; set; }
        public IEnumerable<SelectListItem> DepartamentosList { get; set; }
        public IEnumerable<SelectListItem> ParentescoList { get; set; }
        public IEnumerable<SelectListItem> TipoEmpleoList { get; set; }

        public IEnumerable<SelectListItem> TipoRevistaList { get; set; }

        public string IngresoNeto { get; set; }
        public string NombreEmpleo { get; set; }
    }
}