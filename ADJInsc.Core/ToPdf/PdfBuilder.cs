namespace ADJInsc.Core.ToPdf
{
    using ADJInsc.Models.ViewModels;
    
   

    public class PdfBuilder
    {
        private readonly InscViewModel _post;

        private readonly string _file;

        public PdfBuilder(InscViewModel post, string file)
        {
            _post = post;
            _file = file;
        }

        
    }
}
