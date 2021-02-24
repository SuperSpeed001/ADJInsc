using System;

namespace ADJInsc.Models.ViewModels
{
    public class ResponseViewModel
    {
        public Guid CodigoVerificador { get; set; }
        public int UsuarioId { get; set; }
        public int InscriptoId { get; set; }
        public bool Existe { get; set; }
        public int InscriptoEnGrupoId { get; set; }
        public string Observacion { get; set; }
    }
}
