namespace ADJInsc.Web.Models
{
    using ADJInsc.Models.Model;    
   
    public class GrupoFamiliarViewModel : Persona
    {
        public string NyAPersona {
            get {
                return PersonaNombre + ", " + PersonaApellido;
            }             
        }

    }
}