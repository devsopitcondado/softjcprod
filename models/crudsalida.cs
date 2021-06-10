using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Web;

namespace Softjc.models
{
    public class crudsalida
    {
        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";
        public Object Csalida(Page Salida, String tusuario, DateTime fechaing)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Csalida", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nomusuario", tusuario);
                sqlcmd.Parameters.AddWithValue("@fecha", fechaing);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return "";
        }

        public String Fidsalida()
        {
            String idsalida = "";

            controller.sconex sqlconexion = new controller.sconex();
            
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Fidsalid", sqlconexion.sqlcon);

                sqlcmd.CommandType = CommandType.StoredProcedure;

                int resultid = (int)sqlcmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(resultid.ToString()))
                {
                    idsalida = resultid.ToString();
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return idsalida;
        }

        public Object Cdetailsalida(Page Salida, int nuevoID, string num_serie, string nom_usuario, string vp, string uso, DateTime sfecha, string salida, string num_req, string estado)
        {

            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Cdetailsalida", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@num_ticket", nuevoID);
                sqlcmd.Parameters.AddWithValue("@num_serie", num_serie);
                sqlcmd.Parameters.AddWithValue("@nom_usuario", nom_usuario);
                sqlcmd.Parameters.AddWithValue("@uso", uso);
                sqlcmd.Parameters.AddWithValue("@vp", vp);
                sqlcmd.Parameters.AddWithValue("@fecha", sfecha);
                sqlcmd.Parameters.AddWithValue("@salida", salida);
                sqlcmd.Parameters.AddWithValue("@num_req", num_req);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Salida, typeof(Page), "alerta", error, false);
            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return "";
        }

        public Object Fdetailsalida(GridView SalidaGrd, String nticket)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmddes = new SqlCommand("Fdetailsalida", sqlconexion.sqlcon);
                sqlcmddes.CommandType = CommandType.StoredProcedure;
                sqlcmddes.Parameters.AddWithValue("@num_ticket", nticket);
                using (SqlDataAdapter sdades = new SqlDataAdapter())
                {
                    sdades.SelectCommand = sqlcmddes;
                    using (DataTable dtmar = new DataTable())
                    {
                        sdades.Fill(dtmar);
                        SalidaGrd.DataSource = dtmar;
                        SalidaGrd.DataBind();
                    }
                }
            }
            catch (Exception x)
            {
                return x;
            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return "exitoso";
        }


        public Object Cpasesalida(Page Salida, String desc, String encarg, String recep, String dpirecep, int nticket, DateTime dat)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Cpasesalida", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@descripcion", desc);
                sqlcmd.Parameters.AddWithValue("@encargado", encarg);
                sqlcmd.Parameters.AddWithValue("@receptor", recep);
                sqlcmd.Parameters.AddWithValue("@dpi_receptor", dpirecep);
                sqlcmd.Parameters.AddWithValue("@num_ticket", nticket);
                sqlcmd.Parameters.AddWithValue("@fecha", dat);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                ScriptManager.RegisterStartupScript(Salida, typeof(Page), "alerta", error, false);
                return x;
            }
            finally
            {
                sqlconexion.sqlcon.Close();
                ScriptManager.RegisterStartupScript(Salida, typeof(Page), "alerta", msj, false);
            }
            return "exitoso";
        }

        public String Fidpasesalida()
        {
            String idpasesalida = "";
            controller.sconex sqlconexion = new controller.sconex();
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Fidpsalid", sqlconexion.sqlcon);

                sqlcmd.CommandType = CommandType.StoredProcedure;

                int resultid = (int)sqlcmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(resultid.ToString()))
                {
                    idpasesalida = resultid.ToString();
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return idpasesalida;
        }

        public String Fdesequalsal(String seri)
        {
            String sdestino = "";
            controller.sconex sqlconexion = new controller.sconex();
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Fdesigualsalida", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@numserie", seri);


                string resultdestino = (string)sqlcmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(resultdestino))
                {
                    sdestino = resultdestino;
                }
                else
                {
                    sdestino = "";
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return sdestino;
        }
        public Object Cpasesalidaarchivo(CrystalReportViewer PSCReport, int idpase)
        {
           
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                // Instantiate variables
                ReportDocument reportDocument = new ReportDocument();

                ParameterField NP = new ParameterField();

                ParameterFields NPS = new ParameterFields();

                ParameterDiscreteValue NPSDV = new ParameterDiscreteValue();

                //Set instances for input parameter 1 -  @CustomerID
                NP.Name = "@num_pase";

                NPSDV.Value = idpase;

                NP.CurrentValues.Add(NPSDV);

                NPS.Add(NP);

                //Add the paramField to paramFields


                PSCReport.ParameterFieldInfo = NPS;


                //reportDocument.Load("~/CRV1PST.rpt");
                //string reportPath = Server.MapPath("~/CRPS.rpt");

                string reportPath = System.Web.HttpContext.Current.Server.MapPath("~/CRV1PST.rpt");

                reportDocument.Load(reportPath);

                //Load the report by setting the report source
                PSCReport.ReportSource = reportDocument;
            }
            catch (Exception x)
            {
                return x;
            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return "exitoso";
        }
    }
}