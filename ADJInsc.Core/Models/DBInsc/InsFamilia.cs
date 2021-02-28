using System;
using System.Collections.Generic;

namespace ADJInsc.Core.Models.DBInsc
{
    public partial class InsFamilia
    {
        public int InsfId { get; set; }
        public int? InsfFicha { get; set; }
        public string InsfTipflia { get; set; }
        public string InsfNombre { get; set; }
        public string InsfTipdoc { get; set; }
        public int InsfNumdoc { get; set; }
        public string InsfEstado { get; set; }
        public DateTime InsfFecalt { get; set; }
        public int InsId { get; set; }
        public int? ParentescoKey { get; set; }
        public int? InsfDiscapacitado { get; set; }
        public int? InsfMinero { get; set; }
        public int? InsfVeterano { get; set; }
        public string FechaNacimiento { get; set; }
        public string FecNacDia { get; set; }
        public string FecNacMes { get; set; }
        public string FecNacAnio { get; set; }
    }
}
