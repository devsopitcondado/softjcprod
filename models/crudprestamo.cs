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
    public class crudprestamo
    {
        String error = @"<script type='text/javascript'>
                             alert('Ocurrio un error al actualizar los datos, por favor verifique.');
                        </script>";

        String msj = @"<script type='text/javascript'>
                             alert('Registro Existoso');
                        </script>";

        public Object Cprestamo(Page CMM, String nomusuario, string uso, DateTime dat, string serieprod)
        {

            controller.sconex sqlconexion = new controller.sconex();
            try
            {
                if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                    sqlconexion.sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("Cprestamo", sqlconexion.sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@nom_usuario", nomusuario);
                sqlcmd.Parameters.AddWithValue("@uso", uso);
                sqlcmd.Parameters.AddWithValue("@fecha", dat);
                sqlcmd.Parameters.AddWithValue("@serie_prod", serieprod);
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

        /*
        public Object Rsentrada(GridView Rsentrada)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Rprdent", sqlconexion.sqlcon);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Rsentrada.DataSource = dt;
                        Rsentrada.DataBind();
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


        public Object Rsentradafiltone(GridView Rsentrada, string serie)
        {
            controller.sconex sqlconexion = new controller.sconex();

            int sincoin = 0;

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Rprdentfilt", sqlconexion.sqlcon);



                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@serie", serie);
                sqlcmd.ExecuteNonQuery();


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Rsentrada.DataSource = dt;
                        Rsentrada.DataBind();
                    }
                }

                /* Codigo agregado para pruebas 
                
                if(sqlcmd == null)
                {
                    /* No hay Coincidencias 
                    sincoin = 0;   
                }
                else
                {
                    /* Si hay Coincidencias 
                    sincoin = 1;
                }*/
            /*}
            catch (Exception x)
            {
                return x;
            }
            finally
            {
                sqlconexion.sqlcon.Close();
            }
            return sincoin;
        }*/
        /*
        public Object Rstockprdcat(GridView Rsprdcat)
        {
            controller.sconex sqlconexion = new controller.sconex();

            if (sqlconexion.sqlcon.State == ConnectionState.Closed)
                sqlconexion.sqlcon.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("Rstockprdcat", sqlconexion.sqlcon);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Rsprdcat.DataSource = dt;
                        Rsprdcat.DataBind();
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
        }*/

    }
}