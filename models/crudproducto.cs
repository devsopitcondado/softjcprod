using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.models
{
    public class crudproducto
    {
        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";

        public Object Cproducto(Page CMM, String seri, int idcat, int idmarca, int idmodelo, String nomusuario, DateTime dat, String estad)
        {

            controller.sconex sqlconexion = new controller.sconex();
            try
            {
                if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("Cproducto", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@numserie", seri);
                sqlcmd.Parameters.AddWithValue("@idcategoria", idcat);
                sqlcmd.Parameters.AddWithValue("@idmodelo", idmodelo);
                sqlcmd.Parameters.AddWithValue("@idmarca", idmarca);
                sqlcmd.Parameters.AddWithValue("@nomusuario", nomusuario);
                sqlcmd.Parameters.AddWithValue("@fecha", dat);
                sqlcmd.Parameters.AddWithValue("@estado", estad);
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


        public String Fproducto(Page CMM, String seri)
        {

            String rproducto = "";

            controller.sconex sqlconexion = new controller.sconex();
            try
            {

                if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                    sqlconexion.sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("Fproducto", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@numserie", seri);
                string resultproducto = (string)sqlcmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(resultproducto))
                {
                    rproducto = resultproducto;
                }
                else
                {
                    rproducto = "";
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
            return rproducto;
        }

        public Object Rproducto(GridView ProdGrd)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Rprdentsindestino", sqlconexion.sqlcon);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ProdGrd.DataSource = dt;
                        ProdGrd.DataBind();
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

    

    public Object UPrd(String serie, String estado)
    {
        controller.sconex sqlconexion = new controller.sconex();

        if (sqlconexion.sqlcon.State == ConnectionState.Closed)
            sqlconexion.sqlcon.Open();
        try
        {
            SqlCommand sqlcmd = new SqlCommand("Uproducto", sqlconexion.sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@numserie", serie);
            sqlcmd.Parameters.AddWithValue("@estado", estado);
            sqlcmd.ExecuteNonQuery();
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