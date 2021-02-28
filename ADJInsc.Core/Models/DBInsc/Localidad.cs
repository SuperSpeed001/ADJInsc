using System;
using System.Collections.Generic;

namespace ADJInsc.Core.Models.DBInsc
{
    public partial class Localidad
    {
        public int LocalidadKey { get; set; }
        public int DepartamentoKey { get; set; }
        public string LocalidadDesc { get; set; }

        public virtual Departamento DepartamentoKeyNavigation { get; set; }
    }
}
