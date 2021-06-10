using Softjc.models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.views
{
    public partial class ingseriesadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //rProducto();
            
            rDestino();
            
            //rRstockprdcat();

           if (!IsPostBack) { 

                rProductoEnt();
                
           }

            SetUsername();
        
            SetFecha();

            rPrdEntSDestino();

        }

        public void rProducto()
        {
            models.crudproducto rPrdo = new models.crudproducto();
            //rPrdo.Rproducto(Rproductog);
        }



        /* Nuevo Grid para el producto */

        public void rProductoEnt()
        {
            models.crudentrada rPrdo = new models.crudentrada();
            rPrdo.Rsentrada(Rsentrada);
        }

        public void rDestino()
        {
            models.cruddestino rDesti = new models.cruddestino();
            rDesti.Rdestino(Rprdentcondestinogrid);
        }


        public void rPrdEntSDestino()
        {
            models.cruddestino rpsDesti = new models.cruddestino();
            rpsDesti.RRprdentsindestino(Rprdentsindestinogrid);
        }


        /* Carga inicial para los productos en stock por categoria */

        public void rRstockprdcat(GridView Rsprdcat, string uso, string est)
        {
            models.crudentrada rpsc = new models.crudentrada();
            rpsc.Rstockprdcat(Rsprdcat,uso,est);
        }

        /* Finaliza */


        private void SetUsername()
        {
            user.Text = User.Identity.Name;
        }

        public void autorizacion()
        {

            String nomusuario = user.Text;

            if (nomusuario == @"DIVINF\josselinemilian" || nomusuario == @"DIVINF\vgoperador")
            {
                Response.Redirect("~/views/ingseriesadmin.aspx");
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        DateTime datetoday;
        private void SetFecha()
        {
            models.localinf daet = new models.localinf();
            datetoday = daet.GetDateTime();
            date.Text = daet.GetDateTime().ToString();
        }
        protected void Rserie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }

        protected void Rprdentsindestinogrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }

        String vacio = @"<script type='text/javascript'>
                                     alert('El campo serie no puede ir vacio');
                                </script>";

        protected void update_Click(object sender, EventArgs e)
        {
            if (tserie.Text != "" && tdestino.Text != "" && treq.Text != "")
            {

                models.cruddestino cdestino = new models.cruddestino();

                String tse = tserie.Text;
                String tus = ddluso.SelectedValue;
                String tdes = tdestino.Text;
                String tevp = ddlvp.SelectedValue;
                String tereq = treq.Text;
                String tuser = user.Text;

                cdestino.Cdestino(this, tse, tus, tdes, tevp, tereq, tuser, datetoday);
                tserie.Text = "";
                tdestino.Text = "";
                treq.Text = "";

                models.crudprestamo cprestamo = new models.crudprestamo();
                cprestamo.Cprestamo(this, tuser, tus, datetoday, tse);

                string estad = "NODISP";

                models.crudproducto upestado = new models.crudproducto();
                upestado.UPrd(tse, estad);
                
                //rProducto();
                rDestino();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }
        }

   
        /* protected void Rproductog_SelectedIndexChanged(object sender, EventArgs e)
         {
             serieactual = Rproductog.SelectedRow.Cells[1].Text;
             ImageButton img = (ImageButton)Rproductog.SelectedRow.Cells[0].Controls[0];
             if (img != null)
             {
                 img.ImageUrl = "~/Imagenes/check_post.ico";
             }
             tserie.Text = serieactual;
         }*/

        String serieactual;
        protected void Rprdentsindestinogrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            serieactual = Rprdentsindestinogrid.SelectedRow.Cells[1].Text;

            ImageButton img = (ImageButton)Rprdentsindestinogrid.SelectedRow.Cells[0].Controls[0];
            if (img != null)
            {
                img.ImageUrl = "~/Imagenes/check_post.ico";
            }

            tserie.Text = serieactual;
        }


        String sincoincidencia = @"<script type='text/javascript'>
                                     alert('No se encontraron coincidencias, favor validar.');
                                </script>";

        String serieactualcita;

        protected void Rsentradag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serieactualcita = Rsentrada.SelectedRow.Cells[1].Text;
                ImageButton img = (ImageButton)Rsentrada.SelectedRow.Cells[0].Controls[0];
                if (img != null)
                {
                    img.ImageUrl = "~/Imagenes/check_post.ico";
                }                
                entradaserieprod.Text = serieactualcita;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", sincoincidencia, false);
                rProductoEnt();
            }
        }


        protected void Rsentrada_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            /* Codigo agregado para prueba  Si Funciono*/
            crudentrada filtrarone = new crudentrada();
            filtrarone.Rsentradafiltone(Rsentrada, findseriebin.Text);
            /*Finaliza agregado de prueba  Si Funciono*/
             
            GridView gv = (GridView)sender;            
            gv.PageIndex = e.NewPageIndex;            
            gv.DataBind();

        }

        protected void findseriebin_TextChanged(object sender, EventArgs e)
        {
            Rsentrada.DataBind();
            crudentrada filtrarone = new crudentrada();
            filtrarone.Rsentradafiltone(Rsentrada,findseriebin.Text);

        }

        protected void prdin_Click(object sender, EventArgs e)
        {
            if (entradaserieprod.Text != "")
            {
                models.crudentrada centrada = new models.crudentrada();                
                String tse = entradaserieprod.Text;
                String tus = ddlusoin.SelectedValue;
                
                
                String tevp = ddlvpin.SelectedValue;
                String tuser = user.Text;
                centrada.Centrada(this, tuser, tus, datetoday, tse);

                entradaserieprod.Text = "";

                string estd = "DISP";
                /*rProducto();

                 rDestino(); */

                /* Codigo nuevo - Sirve para actualizar el estado del prodcuto a DISP para que se considere como STOCK */
                  
                models.crudproducto uestprd = new models.crudproducto();
                
                uestprd.UPrd(tse,estd);
                
                //rRstockprdcat();

                rPrdEntSDestino();

                rDestino();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }
        }

        protected void Rprdentcondestinogrid_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        protected void Rprdentcondestinogrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView gv = (GridView)sender;

            gv.PageIndex = e.NewPageIndex;

            gv.DataBind();
        }

        protected void invfiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invfiltro.SelectedItem.Value == "STOCK")
            {
                MultiView1.ActiveViewIndex = 0;
                rRstockprdcat(stocatprd0,invfiltro.SelectedItem.Value, "DISP");
            }
            else if(invfiltro.SelectedItem.Value == "APERTURA DE TIENDA")
            {
                MultiView1.ActiveViewIndex = 1;
                rRstockprdcat(stocatprd1,invfiltro.SelectedItem.Value, "DISP");
            }
            else if(invfiltro.SelectedItem.Value == "ASIGNACION")
            {
                MultiView1.ActiveViewIndex = 2;
                rRstockprdcat(stocatprd2,invfiltro.SelectedItem.Value, "DISP");
            }
        }
    }
}
