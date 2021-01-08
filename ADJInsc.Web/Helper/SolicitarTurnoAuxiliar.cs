namespace ADJInsc.Web.Helper
{
    using ADJInsc.Models.Model;
    using ADJInsc.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Mvc;

    public class SolicitarTurnoAuxiliar
    {
        public string _connectionString { get; set; }
        public FichaViewModel FichaViewModel { get; set; }
        private SqlConnection con;

        public SolicitarTurnoAuxiliar() 
        {            
           
        }

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();     //PRODUCCION
                                                                                                        //string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();       //TEST
            con = new SqlConnection(constr);

        }                   

        public FichaViewModel InicializarModelo()
        {
            Connection();
            string query0 = "SELECT ParentescoKey ,ParentescoDesc FROM Parentesco";
            string query1 = "SELECT TipoFamiliaKey ,TipoFamiliaDesc FROM TipoFamilia";
            string query2 = "SELECT DepartamentoKey ,DepartamentoDesc  FROM Departamento";
            string query3 = "SELECT LocalidadKey ,DepartamentoKey, LocalidadDesc FROM Localidad";

            var response = new FichaViewModel();
                        
            using SqlCommand cmd = new SqlCommand(query0, con)
            {
                CommandType = CommandType.Text
            };

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            using SqlCommand cmd1 = new SqlCommand(query1, con)
            {
                CommandType = CommandType.Text
            };

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            
            using SqlCommand cmd2 = new SqlCommand(query2, con)
            {
                CommandType = CommandType.Text
            };

            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();

            using SqlCommand cmd3 = new SqlCommand(query3, con)
            {
                CommandType = CommandType.Text
            };

            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();

            con.Open();
            da.Fill(dt);
            da1.Fill(dt1);
            da2.Fill(dt2);
            da3.Fill(dt3);


            var pList = new List<Parentesco>();

            foreach (DataRow item in dt.Rows)
            {
                pList.Add(MapToParentesco(item));
            }

            var tfList = new List<TipoFamilia>();
            foreach (DataRow item in dt1.Rows)
            {
                tfList.Add(MapToTipoFamilia(item));
            }

            var dList = new List<Departamento>();
            foreach (DataRow item in dt2.Rows)
            {
                dList.Add(MapToDepartamento(item));
            }

            var lList = new List<Localidad>();
            foreach (DataRow item in dt3.Rows)
            {
                lList.Add(MapToLocalidad(item));
            }

            response.ParentescoList = pList.Select(
                r => new SelectListItem
                {
                    Value = $"{r.ParentescoKey}",
                    Text = r.ParentescoDesc
                }).ToList();

            response.TipoFamiliaList =  tfList.Select(
                r => new SelectListItem
                {
                    Value = $"{r.TipoFamiliaKey}",
                    Text = r.TipoFamiliaDesc
                }).ToList();

            response.DepartamentoList = dList.Select(
                r => new SelectListItem
                {
                    Value = $"{r.DepartamentoKey}",
                    Text = r.DepartamentoDesc
                }).ToList();

            response.LocalidadList = lList.Select(
                r => new SelectListItem
                {
                    Value = $"{r.LocalidadKey}",
                    Text = r.LocalidadDesc
                }).ToList();

            con.Close();

            response.GrupoFamiliar = new List<GrupoFamiliarViewModel>();
            return response;
        }

        #region Metodos Privados
           


        private Localidad MapToLocalidad(DataRow reader)
        {
            return new Localidad
            {
                LocalidadKey = (int)reader["LocalidadKey"],
                DepartamentoKey = (int)reader["DepartamentoKey"],
                LocalidadDesc = (string)reader["LocalidadDesc"]
            };
        }

        private Parentesco MapToParentesco(DataRow reader)
        {           
            return new Parentesco
            {
                 ParentescoKey = (int)reader["ParentescoKey"],
                 ParentescoDesc = (string)reader["ParentescoDesc"]               
            };
        }

        private TipoFamilia MapToTipoFamilia(DataRow reader)
        {

            return new TipoFamilia
            {
                TipoFamiliaKey = (int)reader["TipoFamiliaKey"],
                TipoFamiliaDesc = (string)reader["TipoFamiliaDesc"]
            };
        }

        private Departamento MapToDepartamento(DataRow reader)
        {

            return new Departamento
            {
                DepartamentoKey = (int)reader["DepartamentoKey"],
                DepartamentoDesc = (string)reader["DepartamentoDesc"]
            };
        }

        #endregion


        #region Metodos de sistema web
        /*
         public List<ListadoTurnoViewModel> GetTurnos()
                {
                    connection();
                    using (SqlCommand cmd = new SqlCommand("sp_listarTurnos", con))
                    {                
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        var response = new List<ListadoTurnoViewModel>();
                        con.Open();
                        da.Fill(dt);

                        foreach (DataRow item in dt.Rows)
                        {                   
                            response.Add(MapToValue(item));
                        }
                        return response;
                    }
                }

                public List<TablaTurnosViewModel> ListarHorarioPorFecha(int turnoId, string fecha, string horaMinutosSegundo)
                {
                    connection();
                    var query = horaMinutosSegundo == string.Empty ? "sp_ListarHorarioPorFecha" : "sp_ListarHorarioPorFechaHora";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@tur_id", turnoId));
                        cmd.Parameters.Add(new SqlParameter("@hor_fecha", fecha));

                        if (horaMinutosSegundo != string.Empty)
                            cmd.Parameters.Add(new SqlParameter("@hor_hora", horaMinutosSegundo));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        var response = new List<TablaTurnosViewModel>();
                        con.Open();
                        da.Fill(dt);

                        foreach (DataRow item in dt.Rows)
                        {
                            response.Add(MapToValueFecha(item));
                        }
                        return response;
                    }

                }

                public List<ControlTurnoViewModel> ControlTurno(string dni, int turnoId)
                {
                    connection();
                    using (SqlCommand cmd = new SqlCommand("sp_ControlTurno", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@per_dni", dni));
                        cmd.Parameters.Add(new SqlParameter("@tur_id", turnoId));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        var response = new List<ControlTurnoViewModel>();
                        con.Open();
                        da.Fill(dt);
                        //TODO: Controlar sale exepcion hor_id                   

                        foreach (DataRow item in dt.Rows)
                        {
                            response.Add(MapToVallueControl(item));
                        }
                        return response;

                    }
                }
                                                                                                                //add 2 merge
                public int IncertarPersona(int dni, string nombre, string email, string telefono, int horaId, string observacion)
                {

                    connection();
                    using (SqlCommand cmd = new SqlCommand("sp_insertPersona", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@per_dni", dni.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@per_nombre", nombre));
                        cmd.Parameters.Add(new SqlParameter("@per_email", email));
                        cmd.Parameters.Add(new SqlParameter("@per_telef", telefono));
                        cmd.Parameters.Add("@per_id", SqlDbType.Int, 8);
                        cmd.Parameters["@per_id"].Direction = ParameterDirection.Output;

                        con.Open();
                        var response = 0;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            string personaId = cmd.Parameters["@per_id"].Value.ToString();

                            using (SqlCommand cmd2 = new SqlCommand("sp_updateHorario", con))
                            {
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.Add(new SqlParameter("@hor_id", horaId));
                                cmd2.Parameters.Add(new SqlParameter("@per_id", int.Parse(personaId))); 
                                cmd2.Parameters.Add(new SqlParameter("@hor_obser", (observacion == string.Empty ? " " : observacion) ));       //add 2 merge
                                cmd2.ExecuteNonQuery();
                            }

                            int.TryParse(personaId, out response);
                            return response;
                        }
                        catch (Exception ex)
                        {
                            response = 0;
                            throw ex;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }

                internal byte[] GenerarImagen(PrintViewModel model)
                {
                    Bitmap bitimage;

                    bitimage = (Bitmap)Image.FromFile(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/wwwroot/image/"), "turno.png"));
                    Font myFontLabels = new Font("Calibri", 14);
                    Font myFontLabelP = new Font("Calibri", 10);
                    _ = new SolidBrush(Color.White);

                    Bitmap newimage = string.IsNullOrWhiteSpace(model.Observacion) ? new Bitmap(bitimage.Width, bitimage.Height + 100) : new Bitmap(bitimage.Width, bitimage.Height + 120);
                    Graphics gr = Graphics.FromImage(newimage);
                    gr.DrawImageUnscaled(bitimage, 0, 0);
                    string uniqueFileName;
                    try
                    {
                        gr.DrawString("Turno: " + model.NombreTurno + "   " + model.NombreBox, myFontLabels, Brushes.Brown, new RectangleF(5, bitimage.Height, bitimage.Width, 50));

                        gr.DrawString("Nombre y Apellido TITULAR: " + model.Nombre, myFontLabels, Brushes.Brown, new RectangleF(5, bitimage.Height + 20, bitimage.Width, 50));
                        gr.DrawString("D.N.I. : " + model.Dni, myFontLabels, Brushes.Brown, new RectangleF(5, bitimage.Height + 40, bitimage.Width, 50));
                        gr.DrawString("Fecha: " + model.Fecha + " " + "Hora: " + model.Hora, myFontLabels, Brushes.Brown, new RectangleF(5, bitimage.Height + 60, bitimage.Width, 50));
                        if (string.IsNullOrEmpty(model.Observacion))
                        {
                            gr.DrawString("El turno es válido como permiso de circulación desde tu casa al IVUJ. ", myFontLabelP, Brushes.Brown, new RectangleF(5, bitimage.Height + 80, bitimage.Width, 50));
                        }
                        else
                        {
                            gr.DrawString("Observación: " + model.Observacion, myFontLabels, Brushes.Brown, new RectangleF(5, bitimage.Height + 80, bitimage.Width, 50));
                            gr.DrawString("El turno es válido como permiso de circulación desde tu casa al IVUJ. ", myFontLabelP, Brushes.Brown, new RectangleF(5, bitimage.Height + 100, bitimage.Width, 50));

                        }

                        //l turno es válido como permiso de circulación desde tu casa al IVUJ.
                        //gr.DrawString("El presente Turno es válido para el día solicitado.", myFontLabels, Brushes.Brown, new RectangleF(5, bitimage.Height + 80, bitimage.Width, 50));
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + "Turno";
                        newimage.Save(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/wwwroot/imageTurno/") + uniqueFileName + ".png"));
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    gr.Dispose();
                    bitimage.Dispose();

                    FileStream fileStream = new FileStream(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/wwwroot/imageTurno/") + uniqueFileName + ".png"), FileMode.Open, FileAccess.Read);
                    byte[] data = new byte[(int)fileStream.Length];
                    fileStream.Read(data, 0, data.Length);

                    return data;
                }
         */

        /*
         * 
         * private ListadoTurnoViewModel MapToValue(DataRow reader)
        {
            return new ListadoTurnoViewModel()
            {
                Idturno = (int)reader["tur_id"],
                NombreTurno = reader["tur_nombre"].ToString()
            };
        }

        private TablaTurnosViewModel MapToValueFecha(DataRow reader)
        {
            return new TablaTurnosViewModel()
            {
                hor_id = (int)reader["hor_id"],
                hor_hora = reader["hor_hora"].ToString(),
                hor_dia = reader["hor_dia"].ToString(),
                box_nombre = reader["box_nombre"].ToString(),
                tur_nombre = reader["tur_nombre"].ToString(),
                hor_reserv = (bool)reader["hor_reserv"]
            };            
        }

        private ControlTurnoViewModel MapToVallueControl(DataRow reader)
        {
            if (!reader.IsNull(0))
            {
                return new ControlTurnoViewModel()
                {
                    DiaTurno = reader["Dia"].ToString(),
                    FechaTurno = DateTime.Parse(reader["Fecha"].ToString())//,
                                                                           //HoraTurno = reader["hor_dia"].ToString()
                };
            }
            else
            {
                return new ControlTurnoViewModel();
            }
           
        }

       private ListadoTurnoReservadosViewModel MapToValueGeneric(DataRow reader)
        {

            return new ListadoTurnoReservadosViewModel
            {
                NombreTurno = (string)reader["tur_nombre"],
                Fecha = DateTime.Parse(reader["hor_fecha"].ToString()),
                Dia = (string)reader["hor_dia"],
                Hora = (string)reader["hor_hora"],
                Dni = (string)reader["per_dni"],
                NombrePersona = (string)reader["per_nombre"],
                Observacion = (string)reader["hor_obser"],
                NombreBox = (string)reader["box_nombre"],
                Estado = (bool)reader["hor_reserv"]
                
            };
        }

        private ListadoTurnoReservadosViewModel MapToValueBusqueda(DataRow reader)
        {

            return new ListadoTurnoReservadosViewModel
            {
                IdHora = (int)reader["hor_id"],
                Fecha = DateTime.Parse(reader["hor_fecha"].ToString()),
                Dia = (string)reader["hor_dia"],
                Hora = (string)reader["hor_hora"],
                Dni = (string)reader["per_dni"],
                NombrePersona = (string)reader["per_nombre"],
                Observacion = (string)reader["hor_obser"],
                NombreBox = (string)reader["box_nombre"],
                EmailPersona = (string)reader["per_email"],
                TelefonoPersona = (string)reader["per_telef"]
            };
        }

        private ListadoTurnoReservadosViewModel MapToValueParaCO(DataRow reader)
        {

            return new ListadoTurnoReservadosViewModel
            {
                IdHora = (int)reader["hor_id"],
                Fecha = DateTime.Parse(reader["hor_fecha"].ToString()),
                Dia = (string)reader["hor_dia"],
                Hora = (string)reader["hor_hora"],
                Dni = (string)reader["per_dni"],
                NombrePersona = (string)reader["per_nombre"],
                Observacion = (string)reader["hor_obser"],
                NombreBox = (string)reader["box_nombre"],
                EmailPersona = (string)reader["per_email"],
                TelefonoPersona = (string)reader["per_telef"]
            };
        }
        public List<ListadoTurnoReservadosViewModel> GetTurnosReservados()
        {
            connection();
            var query = "select T.tur_nombre, H.hor_fecha, H.hor_dia, H.hor_hora, P.per_dni, P.per_nombre, H.hor_obser, B.box_nombre, H.hor_reserv from Horarios As H " +
                            " inner join Personas As P on H.per_id = P.per_id " +
                            " inner join Box_Turnos As B on H.box_id = B.box_id " +
                            " inner join Turnos As T on H.tur_id = T.tur_id ";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                var response = new List<ListadoTurnoReservadosViewModel>();
                con.Open();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    response.Add(MapToValueGeneric(item));
                }
                return response;

            }
        }


        public List<ListadoTurnoReservadosViewModel> GetTurnosPorFecha(int turnoId, string dia, string mes, string anio)
        {
            connection();
            var query = "sp_listarTurnosPorFecha";
            var fecha = anio + mes + dia;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@tur_id", turnoId));
                cmd.Parameters.Add(new SqlParameter("@hor_fecha", fecha));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                var response = new List<ListadoTurnoReservadosViewModel>();
                con.Open();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    response.Add(MapToValueBusqueda(item));
                }
                return response;
            }

        }

        public List<ListadoTurnoReservadosViewModel> GetTurnosParaCO(int turnoId, string dia, string mes, string anio)
        {
            connection();
            var query = "sp_listarTurnosPorFecha";
            var fecha = anio + mes + dia;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@tur_id", turnoId));
                cmd.Parameters.Add(new SqlParameter("@hor_fecha", fecha));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                var response = new List<ListadoTurnoReservadosViewModel>();
                con.Open();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    response.Add(MapToValueParaCO(item));
                }
                var listadoConCuenta = GetControlList();
                foreach (var item in listadoConCuenta)
                {
                    foreach (var item2 in response)
                    {
                        if ((int)item.DniTitular == int.Parse(item2.Dni.Trim()) || (int)item.DniCoTitular == int.Parse(item2.Dni.Trim()))
                        {
                            //TODO: CONTROL
                            item2.NumeroCuenta = (int)item.NumeroCuenta;
                        }
                    }
                }
                return response;
            }

        }

          */
        #endregion

    }
}
