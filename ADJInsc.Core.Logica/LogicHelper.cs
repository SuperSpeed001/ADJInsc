namespace ADJInsc.Core.Logica
{
    using ADJInsc.Core.Logica.Service.Settings;
    using ADJInsc.Core.Logica.Service.Interface;
    using ADJInsc.Models.Models.DBInsc;
    using ADJInsc.Models.ViewModels;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Transactions;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class LogicHelper
    {
        public string _connectionString { get; set; }
        private SqlConnection con;
        IMailService _mailService;

        public LogicHelper(string ConnectioonString, IMailService mailService)
        {
            _connectionString = ConnectioonString;
            _mailService = mailService;
        }
        private void Connection()
        {
            //string constr = ConfigurationManager.ConnectionStrings["InscConnection"].ToString();     //PRODUCCION                                                                                                        //string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();       //TEST
            con = new SqlConnection(_connectionString);
        }

        #region Inscripcion
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

        public async Task<ResponseViewModel> PostInscViewModel(InscViewModel inscViewModel)
        {
            Connection();
            var modeloResponse = new ResponseViewModel
            {
                Existe = false
            };

            string query = "UPDATE Inscriptos SET " +
                                                            "  ins_tipflia =  @ins_tipflia, IdTipoFamilia = @IdTipoFamilia, " +
                                                            " ins_nombre = @ins_nombre, ins_numdoc = @ins_numdoc, " +
                                                            " ins_email = @ins_email, " +
                                                            " cuit_cuil = @cuit, cuit_cuil_uno = @cuitUno, cuit_cuil_dos = @cuitDos, " +
                                                            " ins_discapacitado = @ins_disc, ins_minero = @ins_min, ins_veterano = @ins_vet, " +
                                                            " IdDomicilio = @id_domicilio " +
                                                     "WHERE ins_numdoc = " + inscViewModel.InsNumdoc;

            string queryInsertDomicilio = "INSERT INTO InsDomici " +
                                                            " (insd_ficha , insd_direcc , insd_barrio , insd_depar" +
                                                            ", insd_local , insd_refer  , insd_estado "+
                                                            ", IdDepartamento , IdLocalidad)" +
                                                            "  VALUES (" +
                                                            "  @ficha, @direccion, @codBarrio, @codDepto, " +
                                                            "  @codLoc, @referencia, @estado, @codDepto1, @codLoc ); SELECT SCOPE_IDENTITY();";

            string queryInsertLaboral = "INSERT INTO SituacionLaboral  (Nombre ,IngresoNeto ,TipoRevistaKey ,InscriptoId) " +
                                                "VALUES ( @Nombre , @IngresoNeto, @TipoRevistaKey , @InscriptoId ); SELECT SCOPE_IDENTITY(); ";

            string queryInsertGrupo = "INSERT INTO InsFamilia (insf_ficha, insf_tipflia, insf_nombre, insf_tipdoc, insf_numdoc, insf_estado, FechaNacimiento" + 
                                                            " , ins_id, ParentescoKey, insf_discapacitado, insf_minero, insf_veterano) " +
                                                "VALUES       (@insf_ficha, @insf_tipflia, @insf_nombre, @insf_tipdoc, @insf_numdoc, @insf_estado, @FechaNacimiento, " +
                                                            "  @ins_id, @ParentescoKey, @insf_discapacitado, @insf_minero, @insf_veterano); SELECT SCOPE_IDENTITY();";

            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var laboralId = 0m;
                    var personasId = 0m;
                    //1_ insertar domicilio
                    using (SqlCommand cmdInsDomicilio = new SqlCommand(queryInsertDomicilio, con))
                    {
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@ficha", inscViewModel.InsId));
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@direccion", inscViewModel.Direccion.Trim()));
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@codBarrio", "sin barrio"));
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@codDepto", inscViewModel.DepartamentoDesc.Trim()));
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@referencia", "sin referencia"));
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@estado", "I"));  //insert
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@codDepto1", inscViewModel.DepartamentoKey));
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@codLoc", inscViewModel.LocalidadKey));


                        if (con.State == ConnectionState.Closed)
                            await con.OpenAsync();
                        var objetoId = await cmdInsDomicilio.ExecuteScalarAsync();
                        var domicilioId = (objetoId != null) ? (decimal)objetoId : 0;

                        //2_insertar situacion laboral
                        using (SqlCommand cmdInsLaboral = new SqlCommand(queryInsertLaboral, con))
                        {                            
                            cmdInsLaboral.Parameters.Add(new SqlParameter("@Nombre", inscViewModel.NombreEmpleo));
                            cmdInsLaboral.Parameters.Add(new SqlParameter("@IngresoNeto", inscViewModel.IngresoNeto));
                            cmdInsLaboral.Parameters.Add(new SqlParameter("@TipoRevistaKey", inscViewModel.TipoEmpleoKey));
                            cmdInsLaboral.Parameters.Add(new SqlParameter("@InscriptoId", inscViewModel.InsId));

                            if (con.State == ConnectionState.Closed)
                                await con.OpenAsync();
                            var objeto1Id = await cmdInsLaboral.ExecuteScalarAsync();
                            laboralId = (objeto1Id != null) ? (decimal)objeto1Id : 0;

                        }

                        using (SqlCommand cmdInsGrupo = new SqlCommand(queryInsertGrupo,con))
                        {
                            personasId = 1;
                            foreach (var item in inscViewModel.GrupoFamiliar)
                            {
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_ficha", item.InsfFicha));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_tipflia", item.InsfTipflia));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_nombre", item.InsfNombre));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_tipdoc", item.InsfTipdoc));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_numdoc", item.InsfNumdoc));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_estado", "I"));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@FechaNacimiento", item.FechaNacimiento?.Year + "-" + item.FechaNacimiento?.Month + "-" + item.FechaNacimiento?.Day ));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@ins_id", inscViewModel.InsId));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@ParentescoKey", item.ParentescoKey));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_discapacitado", item.InsfDiscapacitado));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_minero", item.InsfMinero));
                                cmdInsGrupo.Parameters.Add(new SqlParameter("@insf_veterano", item.InsfVeterano));
                                

                                if (con.State == ConnectionState.Closed)
                                    await con.OpenAsync();

                                var objId = await cmdInsGrupo.ExecuteScalarAsync();
                                if (objId == null)
                                {
                                    personasId = 0;
                                    break;
                                }
                                else
                                {
                                    personasId = (decimal)objId;
                                }
                            }
                        }

                        if (domicilioId > 0 && laboralId > 0 && personasId > 0)
                        {
                            
                            //insertar o actualizar el Titular
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.Parameters.Add(new SqlParameter("@ins_tipflia", inscViewModel.IdTipoFamilia));
                                cmd.Parameters.Add(new SqlParameter("@IdTipoFamilia", inscViewModel.IdTipoFamilia));
                                cmd.Parameters.Add(new SqlParameter("@ins_nombre", inscViewModel.InsNombre));
                                cmd.Parameters.Add(new SqlParameter("@ins_numdoc", inscViewModel.InsNumdoc));
                                cmd.Parameters.Add(new SqlParameter("@ins_email", inscViewModel.InsEmail));
                                //cmd.Parameters.Add(new SqlParameter("@IdUsuario", inscViewModel.Usuario));
                                cmd.Parameters.Add(new SqlParameter("@cuit", inscViewModel.CuitCuilUno.Trim() + inscViewModel.InsNumdoc.Trim() + inscViewModel.CuitCuilDos.Trim()));
                                cmd.Parameters.Add(new SqlParameter("@cuitUno", inscViewModel.CuitCuilUno));
                                cmd.Parameters.Add(new SqlParameter("@cuitDos", inscViewModel.CuitCuilDos));
                                cmd.Parameters.Add(new SqlParameter("@ins_disc", inscViewModel.Discapacitado));
                                cmd.Parameters.Add(new SqlParameter("@ins_min", inscViewModel.Minero));
                                cmd.Parameters.Add(new SqlParameter("@ins_vet", inscViewModel.Veterano));
                                cmd.Parameters.Add(new SqlParameter("@id_domicilio", (int)domicilioId));
                                

                                if (con.State == ConnectionState.Closed)
                                    await con.OpenAsync();

                                var result = await cmd.ExecuteNonQueryAsync();

                                if (result > 0)
                                {
                                    ts.Complete();
                                    modeloResponse.Existe = true;
                                }
                                else
                                {
                                    ts.Dispose();
                                }
                            }
                        }
                        else
                        {
                            ts.Dispose();
                        }

                    }
                   
                }
                catch(Exception ex)
                {
                    ts.Dispose();
                    
                }
                finally
                {
                    
                    await con.CloseAsync();
                }

                return modeloResponse;
            }

        }

        public async Task<ResponseViewModel> PostServerModelo(ModeloCarga model)
        {
            Connection();
            var modeloResponse = new ResponseViewModel();

            string query = "SELECT Id FROM Usuario where NombreUsuario = @nombreUsuario";

            string insertUsuario = "INSERT INTO Usuario (NombreUsuario, ClaveUsuario) VALUES " +
                " ( @NombreUsuario, @ClaveUsuario ); SELECT SCOPE_IDENTITY();";

            string insertTitular = "INSERT INTO Inscriptos (" +
               "  ins_tipflia, IdTipoFamilia,  ins_nombre, ins_numdoc, ins_email, IdUsuario, ins_estado, cuit_cuil, cuit_cuil_uno, cuit_cuil_dos, ins_telef )" +
               "VALUES " +
               "( @ins_tipflia, @IdTipoFamilia, @ins_nombre,  @ins_numdoc, " +
               "  @ins_email, @IdUsuario, 'A', @cuit, @cuitUno, @cuitDos, @telefono ); SELECT SCOPE_IDENTITY();";

            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (SqlCommand cmdConsulta = new SqlCommand(query, con))
                    {
                        //  *************************     1_ Consultar si existe el email
                        cmdConsulta.CommandType = CommandType.Text;
                        cmdConsulta.Parameters.Add(new SqlParameter("@nombreUsuario", model.usuario));

                        if (con.State == ConnectionState.Closed)
                            await con.OpenAsync();                        
                        
                        var result = await cmdConsulta.ExecuteScalarAsync();    

                        if (result != null)
                            return new ResponseViewModel { Existe = true, UsuarioId = int.Parse(result.ToString()), InscriptoId = 0 };
                        //existe= true, usuarioId > 0, inscriptoId = 0


                        // *************************     2_ Consultar si existe inscripto
                        query = "SELECT ins_id FROM Inscriptos where ins_numdoc = @dni";
                        result = string.Empty;
                        decimal InscriptoId = 0;
                        var objetoId = new object();

                        using (SqlCommand cmdSegundaConsulta = new SqlCommand(query, con))
                        {
                            cmdSegundaConsulta.CommandType = CommandType.Text;
                            cmdSegundaConsulta.Parameters.Add(new SqlParameter("@dni", model.dni));
                            if (con.State == ConnectionState.Closed)
                                await con.OpenAsync();

                            objetoId = await cmdSegundaConsulta.ExecuteScalarAsync();

                            if (objetoId != null)
                            {
                                //****     Si existe el Inscripto entonces debo hacer Update
                                InscriptoId = (decimal)objetoId;
                                insertTitular = "UPDATE Inscriptos SET " +
                                                            "  ins_tipflia =  @ins_tipflia, IdTipoFamilia = @IdTipoFamilia, " + 
                                                            " ins_nombre = @ins_nombre, ins_numdoc = @ins_numdoc, " +
                                                            " ins_email = @ins_email, IdUsuario= @IdUsuario, ins_estado = 'A', " +
                                                            " cuit_cuil = @cuit, cuit_cuil_uno = @cuitUno, cuit_cuil_dos = @cuitDos, ins_telf = @telefono " +
                                                     "WHERE ins_id = " + InscriptoId.ToString();
                                
                                //return new ResponseViewModel { Existe = true, InscriptoId = int.Parse(result), UsuarioId = 0 };
                            }
                            else
                            {
                                objetoId = null;  //limpio el objeto porque no existe el Inscripto, por las dudas obtenga basura
                            }

                            using (SqlCommand cmd = new SqlCommand(insertUsuario, con))
                            {

                                //****************************              3_ insertar el usuario
                                cmd.CommandType = CommandType.Text;

                                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", model.usuario));
                                cmd.Parameters.Add(new SqlParameter("@ClaveUsuario", model.clave));

                                if (con.State == ConnectionState.Closed)
                                    await con.OpenAsync();

                                objetoId = await cmd.ExecuteScalarAsync();

                                var UsuarioId = (objetoId != null) ? (decimal)objetoId : 0;

                                if (UsuarioId == 0) { ts.Dispose(); return new ResponseViewModel { Existe = false, UsuarioId = 0, InscriptoId = 0 }; }

                                modeloResponse.UsuarioId = (int)UsuarioId;
                                //The parameterized query '(@NombreUsuario nvarchar(8),@ClaveUsuario nvarchar(9),@ins_ficha' expects the parameter '@ins_ficha', which was not supplied.
                                using (SqlCommand cmd1 = new SqlCommand(insertTitular, con))
                                {
                                    //*************************************          4_ insertar o Update el Inscripto
                                    cmd1.CommandType = CommandType.Text;

                                    //var nombreApellido = model.nombre.Trim() + ", " + model.apellido.Trim();
                                    int.TryParse(model.tipoFamilia, out int idTipoFlia);

                                    cmd1.Parameters.Add(new SqlParameter("@ins_tipflia", model.tipoFamilia));
                                    cmd1.Parameters.Add(new SqlParameter("@IdTipoFamilia", idTipoFlia));
                                    cmd1.Parameters.Add(new SqlParameter("@ins_nombre", model.nombre.Trim()));
                                    cmd1.Parameters.Add(new SqlParameter("@ins_numdoc", model.dni));
                                    cmd1.Parameters.Add(new SqlParameter("@ins_email", model.email));
                                    cmd1.Parameters.Add(new SqlParameter("@IdUsuario", UsuarioId));
                                    cmd1.Parameters.Add(new SqlParameter("@cuit", model.cuitUno.Trim()  + model.dni.Trim()  + model.cuitTres.Trim() ));
                                    cmd1.Parameters.Add(new SqlParameter("@cuitUno", model.cuitUno));
                                    cmd1.Parameters.Add(new SqlParameter("@cuitDos", model.cuitTres));
                                    cmd1.Parameters.Add(new SqlParameter("@telefono", model.telefono));

                                    if (con.State == ConnectionState.Closed)
                                        await con.OpenAsync();

                                    objetoId = null;  //limpio el objeto                                  

                                    if (InscriptoId > 0)
                                    {
                                        //ejecuto sin obtener el resultado
                                        objetoId = await cmd1.ExecuteScalarAsync();                                       
                                    }
                                    else
                                    {
                                        //ejecuto obteniendo el resultado, o sea el id de Inscripto
                                        objetoId = await cmd1.ExecuteScalarAsync();  //incerto y obtengo el InscriptoId
                                        InscriptoId = (objetoId != null) ? (decimal)objetoId : 0;
                                    }                                        

                                    if (InscriptoId == 0) { ts.Dispose(); return new ResponseViewModel { Existe = false, UsuarioId = 0, InscriptoId = 0 }; }

                                    //************  Si Todo salio Bien =>   obtengo el codigoVerificador
                                    query = "SELECT CodigoVerificador FROM Inscriptos WHERE ins_id = @ins_id ";

                                    using (SqlCommand cmd2 = new SqlCommand(query, con))
                                    {
                                        cmd2.Parameters.Add(new SqlParameter("@ins_id", InscriptoId));

                                        if (con.State == ConnectionState.Closed)
                                            await con.OpenAsync();

                                        objetoId = null;  //limpio el objeto   
                                        objetoId = await cmd2.ExecuteScalarAsync();                                     

                                        if (objetoId != null)
                                        {                                           
                                            modeloResponse.CodigoVerificador= new Guid(objetoId.ToString());
                                        }
                                        else
                                        {
                                            //si no puedo obtener el guid es porque ocurrio un error
                                            //entonces hago dispose y retorno error
                                            ts.Dispose();
                                            return new ResponseViewModel { Existe = false, UsuarioId = 0, InscriptoId = 0 };
                                        }
                                    }

                                    
                                    modeloResponse.InscriptoId = (int)InscriptoId;
                                    modeloResponse.Existe = false;
                                    ts.Complete();

                                    await SendEmail(_mailService, modeloResponse, model.email);

                                }

                            }
                        }

                    }
                    /*var act = (from entidad in db.Activities_activity
                               group entidad by entidad.ActivitiesActivityName into resultDT
                               select new
                               {
                                   ActivityName = resultDT.key,
                                   SumaTotal = resultDT.Sum(x => x.ActivityQuantityTime)
                               }
                               );*/

                    return modeloResponse;
                }
                catch(Exception ex)
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
                ",ins_numdoc ,ins_email ,ins_telef ,ins_estado ,ins_fecalt, ins_discapacitado, ins_minero, " + 
                " ins_veterano, cuit_cuil, cuit_cuil_uno, cuit_cuil_dos, ins_telef FROM Inscriptos where ins_numdoc = @dni";

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
                    pList.InsDiscapacitado = ConvertFromReader<int>(item["ins_discapacitado"]);
                    pList.InsMinero = ConvertFromReader<int>(item["ins_minero"]);
                    pList.InsVeterano = ConvertFromReader<int>(item["ins_veterano"]);
                    pList.CuitCuil = ConvertFromReader<string>(item["cuit_cuil"]);
                    pList.CuitCuilUno = ConvertFromReader<string>(item["cuit_cuil_uno"]);
                    pList.CuitCuilDos = ConvertFromReader<string>(item["cuit_cuil_dos"]);
                    pList.InsTelef = ConvertFromReader<string>(item["ins_telef"]);

                    insId = pList.InsId;

                }
                                
                if (insId > 0)
                {
                    string query1 = "SELECT insf_id , insf_nombre, insf_tipdoc, insf_numdoc, insf_estado, insf_fecalt, ins_id, P.ParentescoDesc, " +
                                   " insf_discapacitado, insf_minero, insf_veterano, FechaNacimiento " +
                                       "FROM InsFamilia F INNER JOIN Parentesco P ON P.ParentescoKey = F.Parentescokey  WHERE  ins_id = @InsId ";
                    
                    
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
                    pList.GrupoFamiliar = new List<GrupoFamiliarViewModel>();
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt1.Rows)
                        {
                            var grupo = MapToFamilia(item);
                            pList.GrupoFamiliar.Add(grupo);
                        }
                    }


                    await con.CloseAsync();
                    return pList;
                }
                else
                {
                    await con.CloseAsync();
                    //return new UsuarioTitularViewModel();
                    return pList;
                }

            }
            else
            {
                await con.CloseAsync();
                return new UsuarioTitularViewModel();
            }


        }
        #endregion
        #region Login
        public async Task<bool> VerificarGuid(Guid guid)
        {
            Connection();

            using TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {

                var query = "UPDATE Inscriptos  SET ins_estado = @estado where CodigoVerificador = @codigo and ins_estado = 'A'";

                using var cmd1 = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                cmd1.Parameters.Add(new SqlParameter("@estado", "E"));
                cmd1.Parameters.Add(new SqlParameter("@codigo", guid));

                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();

                var objetoId = await cmd1.ExecuteScalarAsync();
                var result = (objetoId != null) ? (decimal)objetoId : 0;

                if (result > 0)
                {
                    ts.Complete();
                    return true;
                }
                else
                {
                    ts.Dispose();
                    return false;
                }
            }
            catch
            {
                ts.Dispose();
                return false;
            }
            finally
            {
                await con.CloseAsync();
            }

        }

        public async Task<Guid> ResetPasword(string email)
        {
            Connection();

            using TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {

                var query = "UPDATE Inscriptos  SET CodigoVerificador = newid(), ins_estado = 'A' output inserted.CodigoVerificador where ins_email = @email";

                using var cmd1 = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                cmd1.Parameters.Add(new SqlParameter("@email", email));

                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();

                var result = await cmd1.ExecuteScalarAsync();

                if (result != null )  //  comento porque solo devuelve un string para ado.net && result.GetType() == typeof(Guid)
                {
                    ts.Complete();
                    return new Guid((string)result);
                }
                else
                {
                    ts.Dispose();
                    return Guid.Empty;
                }
            }
            catch
            {
                ts.Dispose();
                return Guid.Empty;
            }
            finally
            {
                await con.CloseAsync();
            }
        }

        //TODO: Actualizar datos del login en la clase que llama
        public async Task<InscViewModel> GetLogin(string usuario, string clave)
        {
            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(clave)) return new InscViewModel();

            Connection();

            string query = string.Empty;
            var pList = new InscViewModel();

            try
            {
               // 1_ obtener datos del titular junto al usuario y clave
                        query =
                            "SELECT ins_id, ins_ficha ,ins_tipflia ,ins_fecins, ins_nombre, ins_tipdoc " +
                                   " ,ins_numdoc ,ins_email ,ins_telef ,ins_estado ,ins_fecalt, cuit_cuil, cuit_cuil_uno, cuit_cuil_dos  FROM Inscriptos as I " +
                            " INNER JOIN Usuario as U on I.IdUsuario = U.Id " +
                            " WHERE U.NombreUsuario = @usuario and U.ClaveUsuario = @clave and I.ins_estado = 'E' ";

                        /*
                            "SELECT ins_id, ins_ficha ,ins_tipflia ,ins_fecins, ins_nombre, ins_tipdoc " +
                                ",ins_numdoc ,ins_email ,ins_telef ,ins_estado ,ins_fecalt FROM Inscriptos where IdUsuario = @idUsuario and ins_estado = 'E' ";
                        */

                        using SqlCommand cmd = new SqlCommand(query, con)
                        {
                            CommandType = CommandType.Text
                        };

                        //cmd.Parameters.Add(new SqlParameter("@idUsuario", (int)idUsuario));
                        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
                        cmd.Parameters.Add(new SqlParameter("@clave", clave));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        if (con.State == ConnectionState.Closed)
                            await con.OpenAsync();

                        da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
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
                        pList.CuitCuil = ConvertFromReader<string>(item["cuit_cuil"]);
                        pList.CuitCuilUno = ConvertFromReader<string>(item["cuit_cuil_uno"]);
                        pList.CuitCuilDos = ConvertFromReader<string>(item["cuit_cuil_dos"]);

                        insId = pList.InsId;

                    }

                    //Aqui obtenemos datos del grupo familiar
                    if (insId > 0)
                    {
                        //2_ obtener datos del grupo familiar
                        query = "SELECT insf_id , insf_nombre, insf_tipdoc, insf_numdoc, insf_estado, insf_fecalt, ins_id, P.ParentescoDesc, insf_discapacitado, insf_minero, insf_veterano, FechaNacimiento  " +
                                           "FROM InsFamilia F INNER JOIN Parentesco P ON P.ParentescoKey = F.Parentescokey  WHERE  ins_id = @InsId ";
                        //select * from Parentesco P inner join InsFamilia F on F.ParentescoKey = P.Parentescokey
                        using SqlCommand cmd1 = new SqlCommand(query, con)
                        {
                            CommandType = CommandType.Text
                        };

                        cmd1.Parameters.Add(new SqlParameter("@InsId", insId));

                        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                        DataTable dt2 = new DataTable();

                        if (con.State == ConnectionState.Closed)
                            await con.OpenAsync();
                        da2.Fill(dt2);

                        if (dt2.Rows.Count > 0)
                        {
                            pList.GrupoFamiliar = new List<GrupoFamiliarViewModel>();
                            foreach (DataRow item in dt2.Rows)
                            {
                                pList.GrupoFamiliar.Add(MapToFamilia(item));
                            }
                        }
                        //await con.CloseAsync();

                    }

                }

                    //por separado obtenemos datos de los combos

                    var listados = new ListadosViewModel();

                    query = "SELECT TipoFamiliaKey ,TipoFamiliaDesc  FROM TipoFamilia";

                    using var cmd2 = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };

                    var da1 = new SqlDataAdapter(cmd2);

                    var dt1 = new DataTable();

                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        var listado = new List<TipoFamilia>();
                        foreach (DataRow row in dt1.Rows)
                        {
                            listado.Add(new TipoFamilia
                            {
                                TipoFamiliaKey = (int)row["TipoFamiliaKey"],
                                TipoFamiliaDesc = (string)row["TipoFamiliaDesc"]
                            });
                        }

                        pList.TipoFamiliaList = listado.Select
                                        (r => new SelectListItem
                                        {
                                            Value = $"{r.TipoFamiliaKey}",
                                            Text = r.TipoFamiliaDesc
                                        })
                                        .OrderBy(o => o.Text)
                                        .ToList();
                    }

                    query = "SELECT LocalidadKey, DepartamentoKey, LocalidadDesc FROM Localidad";
                    using var cmd3 = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };

                    da1 = new SqlDataAdapter(cmd3);

                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        var listado = new List<Localidad>();
                        foreach (DataRow row in dt1.Rows)
                        {
                            listado.Add(new Localidad
                            {
                                LocalidadKey = (int)row["LocalidadKey"],
                                LocalidadDesc = (string)row["LocalidadDesc"],
                                DepartamentoKey = (int)row["DepartamentoKey"]
                            });
                        }
                        pList.LocalidadesList = listado.Select
                                            (r => new SelectListItem
                                            {
                                                Value = $"{r.DepartamentoKey + "-" + r.LocalidadKey}",
                                                Text = r.LocalidadDesc
                                            })
                                            .OrderBy(o => o.Text)
                                            .ToList();
                    }

                    query = "SELECT DepartamentoKey, DepartamentoDesc  FROM Departamento";
                    using var cmd4 = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };

                    da1 = new SqlDataAdapter(cmd4);

                    dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        var listado = new List<Departamento>();
                        foreach (DataRow row in dt1.Rows)
                        {
                            listado.Add(new Departamento
                            {
                                DepartamentoDesc = (string)row["DepartamentoDesc"],
                                DepartamentoKey = (int)row["DepartamentoKey"]
                            });
                        }
                        pList.DepartamentosList = listado.Select(r => new SelectListItem
                                            {
                                                Value = $"{r.DepartamentoKey}",
                                                Text = r.DepartamentoDesc
                                            }).OrderBy(o => o.Text).ToList();
                    }

                    query = "SELECT ParentescoKey, ParentescoDesc FROM Parentesco";
                    using var cmd5 = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };

                    da1 = new SqlDataAdapter(cmd5);

                    dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        var listado = new List<Parentesco>();
                        foreach (DataRow row in dt1.Rows)
                        {
                            listado.Add(new Parentesco
                            {
                                ParentescoKey = (int)row["ParentescoKey"],
                                ParentescoDesc = (string)row["ParentescoDesc"]
                            });
                        }
                        pList.ParentescoList = listado.Select(r => new SelectListItem
                        {
                            Value = $"{r.ParentescoKey}",
                            Text = r.ParentescoDesc
                        }).OrderBy(o => o.Text).ToList();
                    }

                query = "SELECT TipoRevistaKey, TipoRevistaDesc FROM TipoRevista";
                using var cmd6 = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                da1 = new SqlDataAdapter(cmd6);

                dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    var listado = new List<TipoRevista>();
                    foreach (DataRow row in dt1.Rows)
                    {
                        listado.Add(new TipoRevista
                        {
                            TipoRevistaKey = (int)row["TipoRevistaKey"],
                            TipoRevistaDesc = (string)row["TipoRevistaDesc"]
                        });
                    }
                    pList.TipoRevistaList = listado.Select(r => new SelectListItem
                    {
                        Value = $"{r.TipoRevistaKey}",
                        Text = r.TipoRevistaDesc
                    }).OrderBy(o => o.Text).ToList();
                }



                return pList;
            }
            catch
            {
                return pList;
            }
            finally
            {
                await con.CloseAsync();
            }

        }
        #endregion

        #region Metodos varios
        private async Task<bool> SendEmail(IMailService mailService, ResponseViewModel model, string email)
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
            var grupo = new GrupoFamiliarViewModel
            {
                InsId = (int)reader["ins_id"],
                InsfNombre = (string)reader["insf_nombre"],
                InsfTipdoc = (string)reader["insf_tipdoc"],
                InsfNumdoc = (int)reader["insf_numdoc"],
                InsfEstado = (string)reader["insf_estado"],
                InsfFecalt = (DateTime)reader["insf_fecalt"],
                InsfId = (int)reader["insf_id"],
                ParentescoDesc = (string)reader["ParentescoDesc"],
                InsfDiscapacitado = (int)reader["insf_discapacitado"],
                InsfMinero = (int)reader["insf_minero"],
                InsfVeterano = (int)reader["insf_veterano"],
                FechaNacimiento = (DateTime)reader["FechaNacimiento"]
            };

            return grupo;
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
    #endregion

}
