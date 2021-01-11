namespace ADJInsc.Core.Helper
{
    using ADJInsc.Models.Models.DBInsc;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Transactions;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ADJInsc.Core.Service.Interface;
    using ADJInsc.Core.Service;
    using ADJInsc.Models.ViewModels;
    using ADJInsc.Core.FastExcel;
    using System.Globalization;

    public class InscripcionHelper
    {
        public string _connectionString { get; set; }
        private SqlConnection con;

        public InscripcionHelper(string connectionString)
        {
            _connectionString = connectionString;
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

        public async Task<string> InsertDB(List<ExcelModel> excelModel)
        {
            string query = "INSERT INTO TTemp " +
               "( IdPP, Estado, MontoBruto, Monto, MedioPago, Fecha, IdComercio, Informacion, FechaLiquidacion ) " +
               "VALUES ( @IdPP, @Estado, @MontoBruto ,  @Monto  , @MedioPago, @Fecha, @IdComercio, @Informacion, @FechaLiquidacion );  ";

            Connection();
            decimal ok = 0;
            //ok
            var contador = 0;
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                   
                    CultureInfo culture = new CultureInfo("fr-FR");

                    using SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };
                    if (con.State == ConnectionState.Closed)
                         con.Open();

                    cmd.Parameters.Add(new SqlParameter("@IdComercio", SqlDbType.UniqueIdentifier));
                    cmd.Parameters.Add(new SqlParameter("@IdPP", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.NVarChar,200));
                    cmd.Parameters.Add(new SqlParameter("@MontoBruto", SqlDbType.Decimal,18));
                    cmd.Parameters["@MontoBruto"].Precision = 18;
                    cmd.Parameters["@MontoBruto"].Scale = 2;
                    cmd.Parameters.Add(new SqlParameter("@Monto", SqlDbType.Decimal,18));
                    cmd.Parameters["@Monto"].Precision = 18;
                    cmd.Parameters["@Monto"].Scale = 2;
                    cmd.Parameters.Add(new SqlParameter("@MedioPago", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));

                    cmd.Parameters.Add(new SqlParameter("@Informacion", SqlDbType.NVarChar, 200));
                    cmd.Parameters.Add(new SqlParameter("@FechaLiquidacion", SqlDbType.NVarChar, 200));
                    
                    foreach (var row in excelModel)
                    {
                        if (row.IdPP == 1608430)
                        {
                            var uno = 0;
                            var dos = 0;
                        }
                        contador += 1;
                        decimal montoBruto =Convert.ToDecimal(row.MontoBruto);
                        decimal monto = Convert.ToDecimal(row.Monto);
                        cmd.Parameters[0].Value = row.IdComercio;
                        cmd.Parameters[1].Value = row.IdPP;
                        cmd.Parameters[2].Value = row.Estado;
                        cmd.Parameters[3].Value = montoBruto;
                        cmd.Parameters[4].Value = monto;
                        cmd.Parameters[5].Value = row.MedioPago;
                        cmd.Parameters[6].Value = row.Fecha;
                        cmd.Parameters[7].Value = row.Informacion;
                        cmd.Parameters[8].Value = row.FechaLiquidacion;

                        if (cmd.ExecuteNonQuery()!= 1)
                        {
                            ts.Dispose();
                            break;
                        }
                       
                       
                    }

                    if (ok > 0)
                    {
                        ts.Complete();
                    }
                   
                }
                catch (Exception ex)
                {
                    var otro = ex.Message + contador.ToString();
                    ts.Dispose();
                }
                finally
                {
                    ts.Complete();
                    con.Close();
                }
            }
            return "OK";
        }

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

                if(con.State == ConnectionState.Closed)
                    await con.OpenAsync();
                
               var usuarioId = (decimal)await cmd.ExecuteScalarAsync();

                if( usuarioId!=0)
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
                using SqlCommand cmd = new SqlCommand(queryInsertTitular,con)
                {
                    CommandType = CommandType.Text
                };
               
                cmd.Parameters.Add(new SqlParameter("@ins_ficha", inscViewModel.InsFicha));
                cmd.Parameters.Add(new SqlParameter("@ins_tipflia", inscViewModel.InsTipflia));
                cmd.Parameters.Add(new SqlParameter("@ins_fecins", inscViewModel.InsFecins));
                cmd.Parameters.Add(new SqlParameter("@ins_nombre",inscViewModel.InsNombre.Trim()));
                cmd.Parameters.Add(new SqlParameter("@ins_tipdoc", inscViewModel.InsFicha));
                cmd.Parameters.Add(new SqlParameter("@ins_numdoc", inscViewModel.InsFicha));

                cmd.Parameters.Add(new SqlParameter("@ins_email", inscViewModel.InsEmail));
                cmd.Parameters.Add(new SqlParameter("@ins_telef", inscViewModel.InsTelef));
                cmd.Parameters.Add(new SqlParameter("@ins_estado", inscViewModel.InsEstado));
                cmd.Parameters.Add(new SqlParameter("@ins_fecalt", inscViewModel.InsFecalt));

                con.Open();
                inscId =(int)cmd.ExecuteScalar();    //ejecuta y devuelve el primer campo del registro, es decir el id

                if (inscId> 0)
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

        public InscViewModel GetInscripto(int dni)
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

            con.Open();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var pList = new InscViewModel();
                var insId = 0;
                foreach (DataRow item in dt.Rows)
                {
                    pList.InsId = (int)item["ins_id"];
                    pList.InsEmail = (string)item["ins_email"];
                    pList.InsEstado = (string)item["ins_estado"];
                    pList.InsFecalt = (DateTime)item["ins_fecalt"];
                    pList.InsFecins = (string)item["ins_fecins"];
                    pList.InsFicha = (int)item["ins_ficha"];
                    pList.InsNombre = (string)item["ins_nombre"];
                    pList.InsNumdoc = (string)item["ins_numdoc"];
                    pList.InsTelef = (string)item["ins_telef"];
                    pList.InsTipdoc = (string)item["ins_tipdoc"];
                    pList.InsTipflia = (string)item["ins_tipflia"];
                    insId = pList.InsId;
                    
                }

                if (insId > 0)
                {
                    string query1 = "SELECT insf_id , insf_nombre, insf_tipdoc, insf_numdoc, insf_estado, insf_fecalt, ins_id, P.ParentescoDesc " +
                                       "FROM InsFamilia F INNER JOIN Parentesco P ON P.ParentescoKey = F.Parentescokey  WHERE  ins_id = @pList.InsId ";
                    //select * from Parentesco P inner join InsFamilia F on F.ParentescoKey = P.Parentescokey
                    using SqlCommand cmd1 = new SqlCommand(query1, con)
                    {
                        CommandType = CommandType.Text                       
                    };

                    cmd1.Parameters.Add(new SqlParameter("@pList.InsId", pList.InsId));

                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();

                    con.Open();
                    da1.Fill(dt1);

                    foreach (DataRow item in dt1.Rows)
                    {
                        pList.GrupoFamiliar.Add(MapToFamilia(item));
                    }

                    con.Close();
                    return pList;
                }
                else
                {
                    return new InscViewModel();
                }

            }
            else
            {
                return new InscViewModel();
            }

            /*  
             return new InscViewModel(); 
 */
        }

        private async Task<bool> SendEmail(IMailService mailService, string email, string usuario, string clave)
        {
            try
            {
                var request = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Instituto de Vivienda y Urbanismo de Jujuy",
                    Body = string.Format("Prueba realizada por el sistema del IVUJ, Usuario: {0}, Clave: {1}. Gracias.", usuario, clave),
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

    }
}