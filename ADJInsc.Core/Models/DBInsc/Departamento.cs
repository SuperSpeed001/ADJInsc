using System;
using System.Collections.Generic;

namespace ADJInsc.Core.Models.DBInsc
{
    public partial class Departamento
    {
        public Departamento()
        {
            Localidad = new HashSet<Localidad>();
        }

        public int DepartamentoKey { get; set; }
        public string DepartamentoDesc { get; set; }

        public virtual ICollection<Localidad> Localidad { get; set; }
    }
}
