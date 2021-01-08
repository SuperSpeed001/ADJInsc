namespace ADJInsc.Web.Helper
{
    using ADJInsc.Models.Model.DBInsc;
    using ADJInsc.Web.Models;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class InscripcionHelper
    {
        public string _connectionString { get; set; }
        private SqlConnection con;

        public InscripcionHelper() { }

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["InscConnection"].ToString();     //PRODUCCION                                                                                                        //string constr = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();       //TEST
            con = new SqlConnection(constr);
        }

        public InscViewModel GetInscripto(int dni)
        {
            /*Connection();

            string query = "SELECT ins_id, ins_ficha ,ins_tipflia ,ins_fecins, ins_nombre, ins_tipdoc " +
                ",ins_numdoc ,ins_email ,ins_telef ,ins_estado ,ins_fecalt FROM Inscriptos where ins_numdoc = " + dni.ToString();

            using SqlCommand cmd = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };

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

                }

                if (insId > 0)
                {
                    string query1 = "SELECT insf_id , insf_nombre, insf_tipdoc, insf_numdoc, insf_estado, insf_fecalt, ins_id " +
                                       "FROM InsFamilia WHERE ins_id = " + pList.InsId;
                using SqlCommand cmd1 = new SqlCommand(query1, con)
                {
                    CommandType = CommandType.Text
                };
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
            */

            return new InscViewModel();

        }


        private InsFamilia MapToFamilia(DataRow reader)
        {
            return new InsFamilia
            {
                InsId = (int)reader["ins_id"],
                InsfNombre = (string)reader["insf_nombre"],
                InsfTipdoc = (string)reader["insf_tipdoc"],
                InsfNumdoc = (int)reader["insf_numdoc"],
                InsfEstado = (string)reader["insf_estado"],
                InsfFecalt = (DateTime)reader["insf_fecalt"],
                InsfId = (int)reader["insf_id"]
            };
        }



    }
}