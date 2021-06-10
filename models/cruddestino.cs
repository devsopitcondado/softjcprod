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
    public class cruddestino
    {

        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";
        
        public Object Rdestino(GridView DestinoGrd)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmddes = new SqlCommand("Rdestino", sqlconexion.sqlcon);
                sqlcmddes.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sdades = new SqlDataAdapter())
                {
                    sdades.SelectCommand = sqlcmddes;
                    using (DataTable dtmar = new DataTable())
                    {
                        sdades.Fill(dtmar);
                        DestinoGrd.DataSource = dtmar;
                        DestinoGrd.DataBind();
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


        public Object RRprdentsindestino(GridView Rprdentsindestino)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmddes = new SqlCommand("Rprdentsindestino", sqlconexion.sqlcon);
                sqlcmddes.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sdades = new SqlDataAdapter())
                {
                    sdades.SelectCommand = sqlcmddes;
                    using (DataTable dtmar = new DataTable())
                    {
                        sdades.Fill(dtmar);
                        Rprdentsindestino.DataSource = dtmar;
                        Rprdentsindestino.DataBind();
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



        public String Fdestinoreqeon(Page Salida, String req)
        {
            String sdestino = "";

            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("FDestinoreqeon", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@req", req);
                string rdestinoreqex = (string)sqlcmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(rdestinoreqex))
                {
                    sdestino = "";
                }
                else
                {
                    sdestino = "Si existe";
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

        public Object Fdestinoreq(GridView DestinoGrd, String reqe)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmddes = new SqlCommand("FDestinoreq", sqlconexion.sqlcon);
                sqlcmddes.CommandType = CommandType.StoredProcedure;
                sqlcmddes.Parameters.AddWithValue("@req", reqe);
                using (SqlDataAdapter sdades = new SqlDataAdapter())
                {
                    sdades.SelectCommand = sqlcmddes;
                    using (DataTable dtmar = new DataTable())
                    {
                        sdades.Fill(dtmar);
                        DestinoGrd.DataSource = dtmar;
                        DestinoGrd.DataBind();
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


        public Object Cdestino(Page ingresoseriesadmin, String tserie, String tuso, String tdestino, String tvp, String treq, String tusuario, DateTime fechaing)
        {

            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Cdestino", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@numserie", tserie);
                sqlcmd.Parameters.AddWithValue("@uso", tuso);
                sqlcmd.Parameters.AddWithValue("@destino", tdestino);
                sqlcmd.Parameters.AddWithValue("@vp", tvp);
                sqlcmd.Parameters.AddWithValue("@req", treq);
                sqlcmd.Parameters.AddWithValue("@usuario", tusuario);
                sqlcmd.Parameters.AddWithValue("@fecha", fechaing);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(ingresoseriesadmin, typeof(Page), "alerta", error, false);
            }
            finally
            {
                ScriptManager.RegisterStartupScript(ingresoseriesadmin, typeof(Page), "alerta", msj, false);
                sqlconexion.sqlcon.Close();
            }
            return "exitoso";
        }

    }
}