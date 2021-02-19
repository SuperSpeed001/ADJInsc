namespace ADJInsc.Models.ViewModels
{
    using ADJInsc.Models.Models.DBInsc;

    public class GrupoFamiliarViewModel : InsFamilia
    {        
        public string ParentescoDesc { get; set; }

        //1 Si presenta discapacidad, 0 no presenta
        public string Discapacidad {
            get
            {
                return InsfDiscapacitado == 1 ? "SI" : "NO";
            }
        }
        public string Minero
        {
            get
            {
                return InsfMinero == 1 ? "SI" : "NO";
            }
        }
        public string Veterano
        {
            get
            {
                return InsfVeterano == 1 ? "SI" : "NO";
            }
        }

        public string FechaShow
        {
            get
            {
                return FechaNacimiento?.ToShortDateString();
            }
        }

        public string FechaNacViewModel { get; set; }
    }
}