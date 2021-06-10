using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.models
{
    public class crudmarca
    {

        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";
        public Object Cmar(Page CMM, String nommarca, String nomusuario, String estado, DateTime fecha)
        {
            controller.sconex sqlconexion = new controller.sconex();
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Cmarca", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nommarca", nommarca);
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
        public Object Rmarca(ListBox lrmarca)
        {
            controller.sconex sqlconexion = new controller.sconex();
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmdmar = new SqlCommand("Rmarca", sqlconexion.sqlcon);
                sqlcmdmar.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sdamar = new SqlDataAdapter())
                {
                    sdamar.SelectCommand = sqlcmdmar;
                    using (DataTable dtmar = new DataTable())
                    {
                        sdamar.Fill(dtmar);
                        lrmarca.DataSource = dtmar;
                        lrmarca.DataTextField = "nombre";
                        lrmarca.DataValueField = "id";
                        lrmarca.DataBind();
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

        public String Fmarca(Page CMM, String nommarca)
        {

            String rtmarca = "";

            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();

            try
            {
                SqlCommand sqlcmd = new SqlCommand("Fmarca", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nommarca", nommarca);
                string resultmar = (string)sqlcmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(resultmar))
                {
                    rtmarca = resultmar;
                }
                else
                {
                    rtmarca = "";
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

            return rtmarca;
        }
    }
}