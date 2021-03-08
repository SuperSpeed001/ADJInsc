namespace ADJInsc.Core.Api.Service.Inscripcion
{
    //using ADJInsc.Core.Logica.Service.Settings;
    using ADJInsc.Models.ViewModels;
   
    using System.Threading.Tasks;
 
    //using ADJInsc.Core.Logica.Service.Interface;
    using ADJInsc.Core.Logica;
    using ADJInsc.Core.Api.Service.Interface;
    using ADJInsc.Core.Api.Service.Settings;
    using System;
    using ADJInsc.Helper;

    public class InscripcionService
    {
        public string _connectionString { get; set; }
        //private SqlConnection con;
        private LogicHelper helper;
        IMailService _mailService;

        public InscripcionService(string connectionString, IMailService mailService)
        {
            _connectionString = connectionString;
            _mailService = mailService;
            helper = new LogicHelper(_connectionString);
            
        }

       /* private void Connection()
        {
            //string constr = ConfigurationManager.ConnectionStrings["InscConnection"].ToString();     //PRODUCCION                                                                                                        //string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();       //TEST
            con = new SqlConnection(_connectionString);
        }*/

        public async Task<ListadosViewModel> GetListadosInciales()
        {
            var result = await helper.GetListadosInciales();
            return  result; 
        }

        public async Task<ResponseViewModel> PostServerModelo(ModeloCarga model)
        {
            var result = await helper.PostServerModelo(model);
            var Helper = new Helper.EmailSender(result.CodigoVerificador.ToString(),model.email);

            await Helper.SendEmail();
            //await SendEmail( result, model.email);
            return result;
        }

        public async Task<ResponseViewModel> PostInscViewModel(InscViewModel model)
        {
            var result = await helper.PostInscViewModel(model);
            
            return result;
        }

        public async Task<UsuarioTitularViewModel> GetInscripto(int dni)
        {
            var result = await helper.GetInscripto(dni);
            return result;
        }

       /* private async Task<bool> SendEmail(ResponseViewModel model, string email)
        {
            try
            {
                //http://localhost:49999/api/verificador/9809jsijd89a7sekjnpdf
                var url = "<a href=http://190.52.39.140/insc/Api/Verificador/" + model.CodigoVerificador + " > Validar </a>";
                var request = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Instituto de Vivienda y Urbanismo de Jujuy",
                    Body = string.Format("Haga clic en el siguiente enlace para validar sus datos {0} ", url),
                    Attachments = null
                };
                await _mailService.SendEmailAsync(request);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        private GrupoFamiliarViewModel MapToFamilia(DataRow reader)
        {
            return new GrupoFamiliarViewModel
            {
                InsId = (int)reader["ins_id"],
                InsfNombre = (string)reader["insf_nombre"],
                InsfTipdoc = (string)reader["insf_tipdoc"],
                InsfNumdoc = (int)reader["insf_numdoc"],
                InsfEstado = (string)reader["insf_estado"],
                InsfFecalt = (DateTime)reader["insf_fecalt"],
                InsfId = (int)reader["insf_id"],
                ParentescoDesc = (string)reader["ParentescoDesc"]
            };
        }

        public static T ConvertFromReader<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default; // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }*/
    }
}
