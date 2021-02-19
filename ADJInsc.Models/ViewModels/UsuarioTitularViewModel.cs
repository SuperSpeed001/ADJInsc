﻿namespace ADJInsc.Models.ViewModels
{    
    using ADJInsc.Models.Models.DBInsc;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class UsuarioTitularViewModel : Inscriptos
    {         
        public string Usuario { get; set; }   //email
        public string Clave { get; set; }

        public bool Existe { get; set; }

        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public int DomDepartamentoKey { get; set; }
        public int DomLocalidadKey { get; set; }

        public int SituacionLaboralId { get; set; }
        public int TipoEmpleoKey { get; set; }
        public int TipoRevistaKey { get; set; }
        public string IngresoNeto { get; set; }
        public string NombreEmpleo { get; set; }

        public int Minero { get; set; }
        public int Veterano { get; set; }
        public int Discapacitado { get; set; }

        public IEnumerable<SelectListItem> TipoFamiliaList { get; set; }
        public IList<GrupoFamiliarViewModel> GrupoFamiliar { get; set; }

        public List<TipoFamilia> GetListado()
        {
            var tipoFamiliaList = new List<TipoFamilia>();
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 0,
                TipoFamiliaDesc = " "
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 1,
                TipoFamiliaDesc = "MATRIMONIO"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 2,
                TipoFamiliaDesc = "CONCUBINOS CON HIJOS"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 3,
                TipoFamiliaDesc = "SOLICITANTE C/HIJOS UNICAMENTE"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 4,
                TipoFamiliaDesc = "SOLICITANTE Y OTROS"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 5,
                TipoFamiliaDesc = "PERSONA SOLA"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 6,
                TipoFamiliaDesc = "CONCUBINOS Y OTROS(SIN HIJOS)"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 7,
                TipoFamiliaDesc = "MATRIMONIO Y OTROS"
            });
            tipoFamiliaList.Add(new TipoFamilia
            {
                TipoFamiliaKey = 8,
                TipoFamiliaDesc = "UNION CONVIVENCIAL"
            });
            return tipoFamiliaList;
        }
    }
}
