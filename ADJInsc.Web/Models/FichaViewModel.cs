namespace ADJInsc.Web.Models
{
    using ADJInsc.Models.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class FichaViewModel
    {
        public FichaViewModel()
        {
            FichaFechaAlta = DateTime.Now;
            PersonaFecNac = DateTime.Now;
            GrupoFamiliar = new List<GrupoFamiliarViewModel>();
        }

        public int FichaKey { get; set; }
        
        /* ***************************************************************Datos del titular*/
        public DateTime FichaFechaAlta { get; set; }
        public int PersonaKey { get; set; }

        public string PersonaCuit { get; set; }

        public string PersonaDni { get; set; }
        public string PersonaApellido { get; set; }
        public string PersonaNombre { get; set; }
        public int PersonaEstadoCivil { get; set; }
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime PersonaFecNac { get; set; }
        public string PersonaSexo { get; set; }
        [Display(Name = "Discapacitado")]
        public bool PersonaDiscapacidad { get; set; }
        [Display(Name = "Minero")]
        public bool PersonaMinero { get; set; }
        [Display(Name = "Ex. Convatiente de Malvinas")]
        public bool PersonaMalvinas { get; set; }
        public string PersonaTel { get; set; }
        public string PersonaEmail { get; set; }
        public int ParentescoKey { get; set; }

        public string PersonaNyA
        {
            get
            {
                return PersonaApellido + ", " + PersonaNombre;
            }
        }

        [Display(Name = "Seleccione Parentesco...")]
        public List<SelectListItem> ParentescoList { get; set; }
        [Display(Name = "Seleccione Tipo de Familia...")]
        public List<SelectListItem> TipoFamiliaList { get; set; }
        [Display(Name = "Seleccione Departamento...")]
        public List<SelectListItem> DepartamentoList { get; set; }
        [Display(Name = "Seleccione Localidad...")]
        public List<SelectListItem> LocalidadList { get; set; }
        public List<SelectListItem> BarrioList { get; set; }

        /* **********************************************************************   Datos del Grupo Familiar*/
        public List<GrupoFamiliarViewModel> GrupoFamiliar { get; set; }
    }
}