namespace ADJInsc.Web.Models
{
    using ADJInsc.Models.Model.DBInsc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InscViewModel: Inscriptos
    {
        public InscViewModel()
        {
           GrupoFamiliar = new List<InsFamilia>();
        }
        public int LocalidadKey { get; set; }
        public string LocalidadDesc { get; set; }

        public string DepartamentoKey { get; set; }
        public string DepartamentoDesc { get; set; }

        public int InsFFamiliaKey { get; set; }
        public IList<InsFamilia> GrupoFamiliar { get; set; }
        [Required]
        public string NombreVM { get; set; }
        [Required]
        public string ApellidoVM { get; set; }
        [Required]
        public string DniVM { get; set; }
    }
}