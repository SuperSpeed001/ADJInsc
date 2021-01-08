namespace ADJInsc.Core.Api
{
    using ADJInsc.Models.Models.DBInsc;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Transactions;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ADJInsc.Core.Api.Service.Interface;
    using ADJInsc.Core.Api.Service.Settings;
    using ADJInsc.Models.ViewModels;

    public class InscripcionHelper
    {
        public string _connectionString { get; set; }
        private SqlConnection con;
        private IMailService _mailService;

        public InscripcionHelper(string connectionString, IMailService mailService)
        {
            _connectionString = connectionString;
            _mailService = mailService;
        }

        private void Connection()
        {
            //string constr = ConfigurationManager.ConnectionStrings["InscConnection"].ToString();     //PRODUCCION                                                                                                        //string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();       //TEST
            con = new SqlConnection(_connectionString);
        }


        public async Task<ListadosViewModel> GetListadosInciales()
        {
            Connection();
            try
            {
                string query = "SELECT TipoFamiliaKey ,TipoFamiliaDesc  FROM TipoFamilia";
                string query1 = "SELECT LocalidadKey, DepartamentoKey, LocalidadDesc FROM Localidad";
                string query2 = "SELECT DepartamentoKey, DepartamentoDesc  FROM Departamento";
                string query3 = "SELECT ParentescoKey, ParentescoDesc FROM Parentesco";


                using var cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                using var cmd1 = new SqlCommand(query1, con)
                {
                    CommandType = CommandType.Text
                };
                using var cmd2 = new SqlCommand(query2, con)
                {
                    CommandType = CommandType.Text
                };
                using var cmd3 = new SqlCommand(query3, con)
                {
                    CommandType = CommandType.Text
                };

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataTable dt = new DataTable();

                var listados = new ListadosViewModel();

                await con.OpenAsync();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var listado = new List<TipoFamilia>();
                    foreach (DataRow row in dt.Rows)
                    {
                        listado.Add(new TipoFamilia
                        {
                            TipoFamiliaKey = (int)row["TipoFamiliaKey"],
                            TipoFamiliaDesc = (string)row["TipoFamiliaDesc"]
                        });
                    }
                    listados.TipoFamiliaList = listado;
                }

                dt = new DataTable();
                da1.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var listado = new List<Localidad>();
                    foreach (DataRow row in dt.Rows)
                    {
                        listado.Add(new Localidad
                        {
                            LocalidadKey = (int)row["LocalidadKey"],
                            LocalidadDesc = (string)row["LocalidadDesc"],
                            DepartamentoKey = (int)row["DepartamentoKey"]
                        });
                    }
                    listados.LocalidadList = listado;
                }

                dt = new DataTable();
                da2.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var listado = new List<Departamento>();
                    foreach (DataRow row in dt.Rows)
                    {
                        listado.Add(new Departamento
                        {
                            DepartamentoDesc = (string)row["DepartamentoDesc"],
                            DepartamentoKey = (int)row["DepartamentoKey"]
                        });
                    }
                    listados.DepartamentosList = listado;
                }

                dt = new DataTable();
                da3.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var listado = new List<Parentesco>();
                    foreach (DataRow row in dt.Rows)
                    {
                        listado.Add(new Parentesco
                        {
                            ParentescoKey = (int)row["ParentescoKey"],
                            ParentescoDesc = (string)row["ParentescoDesc"]
                        });
                    }
                    listados.ParentescoList = listado;
                }
                await con.CloseAsync();

                return listados;
            }
            catch (Exception ex)
            {
                await con.CloseAsync();
                throw ex;
            }
            finally
            {
                await con.CloseAsync();
            }


        }
       
        public async Task<ResponseViewModel> PostServerModelo(ModeloCarga model)
        {
            Connection();
            var modeloResponse = new ResponseViewModel();
            string query = "SELECT NombreUsuario FROM Usuario where NombreUsuario = @nombreUsuario";

            string insertUsuario = "INSERT INTO Usuario (NombreUsuario, ClaveUsuario) VALUES " +
                " ( @NombreUsuario, @ClaveUsuario ); SELECT SCOPE_IDENTITY();";

            string queryInsertTitular = "INSERT INTO Inscriptos (" +
               "  ins_tipflia, IdTipoFamilia,  ins_nombre, ins_numdoc, ins_email, IdUsuario )" +
               "VALUES " +
               "( @ins_tipflia, @IdTipoFamilia, @ins_nombre,  @ins_numdoc, " +
               "  @ins_email, @IdUsuario ); SELECT SCOPE_IDENTITY();";

            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (SqlCommand cmdConsulta = new SqlCommand(query, con))
                    {
                        cmdConsulta.CommandType = CommandType.Text;
                        cmdConsulta.Parameters.Add(new SqlParameter("@nombreusuario", model.usuario));
                        if (con.State == ConnectionState.Closed)
                            await con.OpenAsync();

                        var result = (string)await cmdConsulta.ExecuteScalarAsync();

                        if (!string.IsNullOrEmpty(result))
                            return new ResponseViewModel { Existe = true, UsuarioId = 1 };

                        query = "SELECT ins_email FROM Inscriptos where ins_email = @email";
                        result = string.Empty;

                        using (SqlCommand cmdSegundaConsulta = new SqlCommand(query, con))
                        {
                            cmdSegundaConsulta.CommandType = CommandType.Text;
                            cmdSegundaConsulta.Parameters.Add(new SqlParameter("@email", model.email));
                            if (con.State == ConnectionState.Closed)
                                await con.OpenAsync();

                            result = (string)await cmdSegundaConsulta.ExecuteScalarAsync();

                            if (!string.IsNullOrEmpty(result))
                                return new ResponseViewModel { Existe = true, InscriptoId = 1 };

                            using (SqlCommand cmd = new SqlCommand(insertUsuario, con))
                            {
                                cmd.CommandType = CommandType.Text;

                                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", model.usuario));
                                cmd.Parameters.Add(new SqlParameter("@ClaveUsuario", model.clave));

                                if (con.State == ConnectionState.Closed)
                                    await con.OpenAsync();

                                var UsuarioId = (decimal)await cmd.ExecuteScalarAsync();

                                if (UsuarioId < 0) { ts.Dispose(); return new ResponseViewModel { Existe = false, UsuarioId = 0, InscriptoId = 0 }; }

                                modeloResponse.UsuarioId = (int)UsuarioId;
                                //The parameterized query '(@NombreUsuario nvarchar(8),@ClaveUsuario nvarchar(9),@ins_ficha' expects the parameter '@ins_ficha', which was not supplied.
                                using (SqlCommand cmd1 = new SqlCommand(queryInsertTitular, con))
                                {
                                    cmd1.CommandType = CommandType.Text;

                                   // var nombreApellido = model.nombre.Trim() + ", " + model.apellido.Trim();
                                    int.TryParse(model.tipoFamilia, out int idTipoFlia);

                                    cmd1.Parameters.Add(new SqlParameter("@ins_tipflia", model.tipoFamilia));
                                    cmd1.Parameters.Add(new SqlParameter("@IdTipoFamilia", idTipoFlia));
                                    cmd1.Parameters.Add(new SqlParameter("@ins_nombre", model.nombre.Trim()));
                                    cmd1.Parameters.Add(new SqlParameter("@ins_numdoc", model.dni));
                                    cmd1.Parameters.Add(new SqlParameter("@ins_email", model.email));
                                    cmd1.Parameters.Add(new SqlParameter("@IdUsuario", UsuarioId));

                                    if (con.State == ConnectionState.Closed)
                                        await con.OpenAsync();

                                    var InscriptoId = (decimal)await cmd1.ExecuteScalarAsync();

                                    if (InscriptoId < 0) { ts.Dispose(); return new ResponseViewModel{ Existe = false, UsuarioId = 0, InscriptoId = 0 }; }

                                    modeloResponse.InscriptoId = (int)InscriptoId;
                                    modeloResponse.Existe = false;
                                    ts.Complete();

                                    await SendEmail(_mailService, modeloResponse, model.email);                                   

                                }

                            }
                        }

                    }


                    return modeloResponse;
                }
                catch
                {
                    ts.Dispose();
                    await con.CloseAsync();
                    return new ResponseViewModel();
                }
                finally
                {
                    await con.CloseAsync();
                }
            }

        }

        public async Task<UsuarioTitularViewModel> GetInscripto(int dni)
        {
            Connection();

            string query = "SELECT ins_id, ins_ficha ,ins_tipflia ,ins_fecins, ins_nombre, ins_tipdoc " +
                ",ins_numdoc ,ins_email ,ins_telef ,ins_estado ,ins_fecalt FROM Inscriptos where ins_numdoc = @dni";

            using SqlCommand cmd = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            cmd.Parameters.Add(new SqlParameter("@dni", dni.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            if (con.State == ConnectionState.Closed)
                await con.OpenAsync();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var pList = new UsuarioTitularViewModel();
                var insId = 0;
                foreach (DataRow item in dt.Rows)
                {
                    pList.InsId = ConvertFromReader<int>(item["ins_id"]);
                    pList.InsEmail = ConvertFromReader<string>(item["ins_email"]);
                    pList.InsEstado = ConvertFromReader<string>(item["ins_estado"]);
                    pList.InsFecalt = (DateTime)item["ins_fecalt"];
                    pList.InsFecins = ConvertFromReader<string>(item["ins_fecins"]);
                    pList.InsFicha = ConvertFromReader<int>(item["ins_ficha"]);
                    pList.InsNombre = ConvertFromReader<string>(item["ins_nombre"]);
                    pList.InsNumdoc = ConvertFromReader<string>(item["ins_numdoc"]);
                    pList.InsTelef = ConvertFromReader<string>(item["ins_telef"]);
                    pList.InsTipdoc = ConvertFromReader<string>(item["ins_tipdoc"]);
                    pList.InsTipflia = ConvertFromReader<string>(item["ins_tipflia"]);
                    insId = pList.InsId;

                }

                if (insId > 0)
                {
                    string query1 = "SELECT insf_id , insf_nombre, insf_tipdoc, insf_numdoc, insf_estado, insf_fecalt, ins_id, P.ParentescoDesc " +
                                       "FROM InsFamilia F INNER JOIN Parentesco P ON P.ParentescoKey = F.Parentescokey  WHERE  ins_id = @InsId ";
                    //select * from Parentesco P inner join InsFamilia F on F.ParentescoKey = P.Parentescokey
                    using SqlCommand cmd1 = new SqlCommand(query1, con)
                    {
                        CommandType = CommandType.Text
                    };

                    cmd1.Parameters.Add(new SqlParameter("@InsId", insId));

                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();

                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt1.Rows)
                        {
                            pList.GrupoFamiliar.Add(MapToFamilia(item));
                        }
                    }
                    

                    await con.CloseAsync();
                    return pList;
                }
                else
                {
                    await con.CloseAsync();
                    return new UsuarioTitularViewModel();
                }

            }
            else
            {
                await con.CloseAsync();
                return new UsuarioTitularViewModel();
            }


        }

        private async Task<bool> SendEmail(IMailService mailService, ResponseViewModel model, string email )
        {
            try
            {
                var url = "http://190.52.39.140/" + "AQUI VA EL CONTROLADOR QUE ESTA ESCUCHANDO" + "?id=" + model.CodigoVerificador;
                var request = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Instituto de Vivienda y Urbanismo de Jujuy",
                    Body = string.Format("Haga clic en el siguiente enlace para validar sus datos {0} ", url),
                    Attachments = null
                };
                await mailService.SendEmailAsync(request);
                return true;
            }
            catch
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
        }
    }
}


#region   Metodos que no se usan, para test que si funcionaron

/*
  public async Task<string> InsertTest(string usuario, string clave, string email, IMailService mailService)
        {
            string query = "INSERT INTO Usuario " +
                "(NombreUsuario, ClaveUsuario) " +
                "VALUES (@Usuario, @Clave); SELECT SCOPE_IDENTITY()";

            // var usuarioId = Guid.Empty;
            Connection();
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.Add(new SqlParameter("@Usuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@Clave", clave));

                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();

                var usuarioId = (decimal)await cmd.ExecuteScalarAsync();

                if (usuarioId != 0)
                {
                    ts.Complete();
                    var result = await SendEmail(mailService, email, usuario, clave);

                    if (result)
                    {
                        return string.Format("Se envio un Email a {0}, Verifique su correo.", email);
                    }
                }
                else
                {
                    ts.Dispose();
                }
            }

            return string.Format("Algo Salio Mal");
        }

        public int InsertTotal(InscViewModel inscViewModel)
        {
            string queryInsertTitular = "INSERT INTO Inscriptos " +
                " (ins_ficha, ins_tipflia, ins_fecins, ins_nombre, ins_tipdoc, ins_numdoc, ins_email, ins_telef, ins_estado, ins_fecalt " +
                "VALUES " +
                "( @ins_ficha, @ins_tipflia, @ins_fecins, @ins_nombre, @ins_tipdoc, @ins_numdoc, " +
                "  @ins_email, @ins_telef, @ins_estado, @ins_fecalt )";

            var inscId = 0;
            Connection();
            using (TransactionScope ts = new TransactionScope())
            {
                using SqlCommand cmd = new SqlCommand(queryInsertTitular, con)
                {
                    CommandType = CommandType.Text
                };
                var nombreApellido = inscViewModel.NombreVM.Trim() + ", " + inscViewModel.ApellidoVM.Trim();
                cmd.Parameters.Add(new SqlParameter("@ins_ficha", inscViewModel.InsFicha));
                cmd.Parameters.Add(new SqlParameter("@ins_tipflia", inscViewModel.InsTipflia));
                cmd.Parameters.Add(new SqlParameter("@ins_fecins", inscViewModel.InsFecins));
                cmd.Parameters.Add(new SqlParameter("@ins_nombre", nombreApellido.Trim()));
                cmd.Parameters.Add(new SqlParameter("@ins_tipdoc", inscViewModel.InsFicha));
                cmd.Parameters.Add(new SqlParameter("@ins_numdoc", inscViewModel.InsFicha));

                cmd.Parameters.Add(new SqlParameter("@ins_email", inscViewModel.InsEmail));
                cmd.Parameters.Add(new SqlParameter("@ins_telef", inscViewModel.InsTelef));
                cmd.Parameters.Add(new SqlParameter("@ins_estado", inscViewModel.InsEstado));
                cmd.Parameters.Add(new SqlParameter("@ins_fecalt", inscViewModel.InsFecalt));

                con.Open();
                inscId = (int)cmd.ExecuteScalar();    //ejecuta y devuelve el primer campo del registro, es decir el id

                if (inscId > 0)
                {
                    ts.Complete();
                }
                else
                {
                    ts.Dispose();
                }
            }

            return inscId;
        }
 

public async Task<ResponseViewModel> GetUsuario(ModeloCarga modeloCarga)
        {
            Connection();
            var modeloResponse = new ResponseViewModel();
            string query;

            if (string.IsNullOrEmpty(modeloCarga.email))
            {
                query = "SELECT NombreUsuario FROM Usuario where NombreUsuario = @nombreUsuario";
                modeloResponse.UsuarioId = 1;
            }
            else
            {
                query = "SELECT ins_email FROM Inscriptos where ins_email = @email";
                modeloResponse.InscriptoId = 1;
            }
            
            using SqlCommand cmd = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };

            if (string.IsNullOrEmpty(modeloCarga.email))
            {
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", modeloCarga.usuario));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@email", modeloCarga.email));
            }
               
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            await con.OpenAsync();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                modeloResponse.Existe = true;
                return modeloResponse ;
            }
            modeloResponse.Existe = false;
            return modeloResponse;

        }
 
 */
#endregion