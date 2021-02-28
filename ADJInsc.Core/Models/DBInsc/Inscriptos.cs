using System;
using System.Collections.Generic;

namespace ADJInsc.Core.Models.DBInsc
{
    public partial class Inscriptos
    {
        public int InsId { get; set; }
        public int? InsFicha { get; set; }
        public string InsTipflia { get; set; }
        public string InsFecins { get; set; }
        public string InsNombre { get; set; }
        public string InsTipdoc { get; set; }
        public string InsNumdoc { get; set; }
        public string InsEmail { get; set; }
        public string InsTelef { get; set; }
        public string InsEstado { get; set; }
        public DateTime? InsFecalt { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdDomicilio { get; set; }
        public int? IdTipoFamilia { get; set; }
        public Guid? CodigoVerificador { get; set; }
        public string CuitCuil { get; set; }
        public string CuitCuilUno { get; set; }
        public string CuitCuilDos { get; set; }
        public int? InsDiscapacitado { get; set; }
        public int? InsMinero { get; set; }
        public int? InsVeterano { get; set; }
    }
}
