namespace ADJInsc.Models.ViewModels
{
    using ADJInsc.Models.Models.DBInsc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GrupoFamiliarViewModel : InsFamilia
    {
        public string InsNombre { get; set; }
        public string InsApellido { get; set; }
        //public int ParentescoKey { get; set; }
        public string ParentescoDesc { get; set; }

        public string InsNombreYApellido {
            get
            {
                if (string.IsNullOrEmpty(InsNombre) && string.IsNullOrEmpty(InsApellido))
                {
                    return InsfNombre;
                }
                else
                {
                    return InsNombre + ", " + InsApellido;
                }
               
            }
             
        }

        public string FechaNacimiento { get; set; }

        //1 Si presenta discapacidad, 0 no presenta
        /*public string Discapacidad { get; set; }
        public string Minero { get; set; }
        public string Veterano { get; set; }*/
    }
}