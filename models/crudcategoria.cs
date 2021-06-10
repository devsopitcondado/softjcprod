using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.models
{
    public class crudcategoria

    {
        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";

        public Object Ccat(Page CMM, String nomcat, String nomusuario, String estado, DateTime fecha)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Ccategoria", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nomcategoria", nomcat);
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

        public Object Rcategoria(ListBox lrcategoria)
        {

            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)

                sqlconexion.sqlcon.Open();

            try
            {
                SqlCommand sqlcmd = new SqlCommand("Rcategoria", sqlconexion.sqlcon);

                sqlcmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);

                        lrcategoria.DataSource = dt;
                        lrcategoria.DataTextField = "nombre";
                        lrcategoria.DataValueField = "id";
                        lrcategoria.DataBind();
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

        public String Fcategoria(Page CMM, String nombrecategoria)
        {
            String rtcategoria = "";
            controller.sconex sqlconexion = new controller.sconex();
            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Fcategoria", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nomcategoria", nombrecategoria);
                string result = (string)sqlcmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(result))
                {
                    rtcategoria = result;
                }
                else
                {
                    rtcategoria = "";
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
            return rtcategoria;
        }
    }
}