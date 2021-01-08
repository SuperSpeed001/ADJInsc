namespace ADJInsc.Models.ViewModels
{
    using ADJInsc.Models.Models.DBInsc;
    using System.Collections.Generic;

    public class ListadosViewModel
    {
        public IEnumerable<TipoFamilia> TipoFamiliaList { get; set; }
        public IEnumerable<Departamento> DepartamentosList { get; set; }
        public IEnumerable<Localidad> LocalidadList { get; set; }
        public IEnumerable<Parentesco> ParentescoList { get; set; }
        public IEnumerable<TipoRevista> TipoRevista { get; set; }
    }
}
