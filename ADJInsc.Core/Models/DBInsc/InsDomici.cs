using System;
using System.Collections.Generic;

namespace ADJInsc.Core.Models.DBInsc
{
    public partial class InsDomici
    {
        public int InsdId { get; set; }
        public int InsdFicha { get; set; }
        public string InsdDirecc { get; set; }
        public string InsdBarrio { get; set; }
        public string InsdDepar { get; set; }
        public string InsdLocal { get; set; }
        public string InsdRefer { get; set; }
        public string InsdEstado { get; set; }
        public DateTime InsdFecalt { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdLocalidad { get; set; }
        public int? InsId { get; set; }
    }
}
