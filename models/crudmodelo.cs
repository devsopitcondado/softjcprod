using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.models
{
    public class crudmodelo
    {

        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";
        public Object Cmod(Page CMM, String nommodelo, String nomusuario, String estado, DateTime fecha)
        {
           controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Cmodelo", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nommodelo", nommodelo);
                sqlcmd.Parameters.AddWithValue("@nomusuario", nomusuario);
                sqlcmd.Parameters.AddWithValue("@estado", estado);
                sqlcmd.Parameters.AddWithValue("@fecha", fecha);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(CMM, typeof(Page), "alerta", error, false);
            }
            finally
            {
                sqlconexion.sqlcon.Close();

                ScriptManager.RegisterStartupScript(CMM, typeof(Page), "alerta", msj, false);
            }
            return "exitoso";
        }

        public Object Rmodelo(ListBox lrmodelo)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmdm = new SqlCommand("Rmodelo", sqlconexion.sqlcon);
                sqlcmdm.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sdam = new SqlDataAdapter())
                {
                    sdam.SelectCommand = sqlcmdm;
                    using (DataTable dtm = new DataTable())
                    {
                        sdam.Fill(dtm);

                        lrmodelo.DataSource = dtm;
                        lrmodelo.DataTextField = "nombre";
                        lrmodelo.DataValueField = "id";
                        lrmodelo.DataBind();
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

        public String Fmodelo(Page CMM, String nommodelo)
        {
            String rtmodelo = "";
            controller.sconex sqlconexion = new controller.sconex();
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Fmodelo", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nommodelo", nommodelo);
                string resultmod = (string)sqlcmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(resultmod))
                {
                    rtmodelo = resultmod;
                }
                else
                {
                    rtmodelo = "";
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(CMM, typeof(Page), "alerta", error, false);
            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return rtmodelo;
        }

    }
}