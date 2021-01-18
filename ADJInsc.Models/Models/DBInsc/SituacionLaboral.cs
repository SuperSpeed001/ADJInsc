using System;
using System.Collections.Generic;

namespace ADJInsc.Models.Models.DBInsc
{
    public partial class SituacionLaboral
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string IngresoNeto { get; set; }
        public int? TipoRevistaKey { get; set; }
        public int? InscriptoId { get; set; }
    }
}
