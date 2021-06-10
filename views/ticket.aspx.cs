using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.views
{
    public partial class ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetFecha();
            SetUsername();
        }


        String yaexiste = @"<script type='text/javascript'>
                             alert('Ocurrio un error al buscar los datos, el numero de requerimiento ya fue utilizado, por favor verifique.');
                        </script>";

        String noexiste = @"<script type='text/javascript'>
                             alert('Al buscar los datos, el numero de requerimiento aun no ha sido utilizado.');
                        </script>";

        String vacio = @"<script type='text/javascript'>
                                     alert('El campo requerimiento no puede ir vacio');
                                </script>";

        public void SetUsername()
        {
            user.Text = User.Identity.Name;
        }

        DateTime datetoday;
        private void SetFecha()
        {
            models.localinf daet = new models.localinf();
            datetoday = daet.GetDateTime();
            date.Text = daet.GetDateTime().ToString();
        }

        protected void SalidaGrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }
        protected void Rdestino_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }

        public void rDestino()
        {
            //Controlador.Consultas fDesti = new Controlador.Consultas();
            //fDesti.Fdestinosalida(Fdestino);
        }


        public void rSalida()
        {
            //Controlador.MBus rSali = new Controlador.MBus();
            //rSali.Rsalida(SalidaGrd);
        }



        public String estadosalida()
        {
            String fserie = tserie.Text;

            String estatus = "";

            models.crudsalida fdestesal = new models.crudsalida();

            String rfserie = fdestesal.Fdesequalsal(fserie);


            String fsalida = tsalida.Text;

            if (rfserie == fsalida)
            {
                
                estatus = "COMPLETADO";

            }
            else if (rfserie != fsalida)
            {

                estatus = "PENDIENTE";

            }
            return estatus;
        }



        protected void update_Click(object sender, EventArgs e)
        {
            /*
             if (tserie.Text != "" && tsalida.Text != "" && treq.Text != "")
             {

                 String restatus = estadosalida();

                 Controlador.MBus csalida = new Controlador.MBus();
                 String tse = tserie.Text;
                 String tus = ddluso.SelectedValue;
                 String tsal = tsalida.Text;
                 //String tevp = 
                 String tereq = treq.Text;
                 String tuser = user.Text;

                 csalida.Csalida(this, tse, tus, tsal, tevp, tereq, tuser, dateT, restatus);

                 tserie.Text = "";
                 tsalida.Text = "";
                 treq.Text = "";
             }
             else
             {
                 ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
             }

             rDestino();
             rSalida();
            

            //Fdestino.DataBind();*/

            Detailsalida();

        }

        protected void findredestino_Click(object sender, EventArgs e)
        {
            if (treqfind.Text != "") { 

            models.cruddestino fDesti = new models.cruddestino();

            String freqdes = treqfind.Text;

            string validarvalor = fDesti.Fdestinoreqeon(this, freqdes);

            if (validarvalor == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", yaexiste, false);
                treqfind.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", noexiste, false);
                fDesti.Fdestinoreq(Fdestino, freqdes);
            }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }
        }
        

        String serieactual;
        String destinochange;
        String vpsalida;
        String requer;
        protected void Fdestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Revisar mas adelante

            models.cruddestino setdatades = new models.cruddestino();

            String freqdest = treqfind.Text;

            setdatades.Fdestinoreq(Fdestino, freqdest);

            serieactual = Fdestino.SelectedRow.Cells[1].Text;
            destinochange = Fdestino.SelectedRow.Cells[3].Text;
            vpsalida = Fdestino.SelectedRow.Cells[4].Text;
            requer = Fdestino.SelectedRow.Cells[5].Text;


            ImageButton img = (ImageButton)Fdestino.SelectedRow.Cells[0].Controls[0];

            if (img != null)
            {
                img.ImageUrl = "~/Imagenes/check_post.ico";

            }

            tserie.Text = serieactual;
            tsalida.Text = destinochange;
            tvice.Text = vpsalida;
            treqeq.Text = requer;

        }

        protected void Fdestino_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            models.cruddestino setdatades = new models.cruddestino();
            String freqdest = treqfind.Text;
            setdatades.Fdestinoreq(Fdestino, freqdest);

            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }



        public DataTable filldata()
        {
            DataTable dts = new DataTable();
            dts.Columns.Add("SERIE", typeof(string));
            dts.Columns.Add("SALIDA", typeof(string));
            dts.Columns.Add("USO", typeof(string));
            dts.Columns.Add("VP", typeof(string));
            dts.Columns.Add("REQUERIMIENTO", typeof(string));
            dts.Columns.Add("ESTADO", typeof(string));
            dts.Columns.Add("USUARIO", typeof(string));
            dts.Columns.Add("FECHA", typeof(DateTime));
            return dts;
        }


        public void Detailsalida()
        {


            if (Session["dts"] == null)
            {
                String restatus = estadosalida();

                DataTable dts = filldata();
                DataRow Row1;
                Row1 = dts.NewRow();
                Row1["SERIE"] = tserie.Text;
                Row1["SALIDA"] = tsalida.Text;
                Row1["USO"] = ddluso.SelectedItem.ToString();
                Row1["VP"] = tvice.Text;
                Row1["REQUERIMIENTO"] = treqeq.Text;
                Row1["ESTADO"] = restatus;
                Row1["USUARIO"] = user.Text;
                Row1["FECHA"] = datetoday;
                dts.Rows.Add(Row1);
                SalidaGrd.DataSource = dts;
                SalidaGrd.DataBind();
                Session["dts"] = dts;
            }
            else
            {
                String restatus = estadosalida();

                DataTable dts = (Session["dts"]) as DataTable;
                DataRow Row1;
                Row1 = dts.NewRow();
                Row1["SERIE"] = tserie.Text;
                Row1["SALIDA"] = tsalida.Text;
                Row1["USO"] = ddluso.SelectedItem.ToString();
                Row1["VP"] = tvice.Text;
                Row1["REQUERIMIENTO"] = treqeq.Text;
                Row1["ESTADO"] = restatus;
                Row1["USUARIO"] = user.Text;
                Row1["FECHA"] = datetoday;
                dts.Rows.Add(Row1);
                SalidaGrd.DataSource = dts;
                SalidaGrd.DataBind();
                Session["dts"] = dts;
            }
        }

        protected void editsalida_CheckedChanged(object sender, EventArgs e)
        {
            if (editsalida.Checked)
            {
                tsalida.Enabled = true;

                treqeq.Enabled = true;

            }
            else
            {
                tsalida.Enabled = false;

                treqeq.Enabled = false;
            }
        }


        protected void SalidaGrd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dts = (DataTable)Session["dts"];
            dts.Rows.RemoveAt(e.RowIndex);
            Session["dts"] = dts;

            SalidaGrd.DataSource = dts;
            SalidaGrd.DataBind();
        }

        public void recorrer()
        {

            foreach (GridViewRow row in SalidaGrd.Rows)
            {

                string serie = row.Cells[1].Text;
                string salida = row.Cells[2].Text;
                string uso = row.Cells[3].Text;
                string vp = row.Cells[4].Text;
                string req = row.Cells[5].Text;
                string estado = row.Cells[6].Text;
                DateTime dateTime = Convert.ToDateTime(row.Cells[7].Text);

            }


        }


        protected void Finalizar_Click(object sender, EventArgs e)
        {
            String tuser = user.Text;

            models.crudsalida csalida = new models.crudsalida();

            csalida.Csalida(this, tuser, datetoday);

            models.crudsalida csalidacon = new models.crudsalida();


            String idsalstr = csalidacon.Fidsalida();

            int idsal = Int32.Parse(idsalstr);

            foreach (GridViewRow row in SalidaGrd.Rows)
            {
                string serie = row.Cells[1].Text;
                string salida = row.Cells[2].Text;
                string uso = row.Cells[3].Text;
                string vp = row.Cells[4].Text;
                string req = row.Cells[5].Text;
                string estado = row.Cells[6].Text;
                string usuario = row.Cells[7].Text;
                DateTime dateTime = Convert.ToDateTime(row.Cells[8].Text);
                csalida.Cdetailsalida(this, idsal, serie, usuario, uso, vp, dateTime, salida, req, estado);
            }


            String ntick = @"<script type='text/javascript'>
                             titulo = 'Su numero de ticket es: {0}'
                             alert(titulo);</script>";

            string ae = string.Format(ntick, idsal);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", ae, false);

            limpiar();
        }

        public void limpiar()
        {
            Session["dts"] = null;
            SalidaGrd.DataBind();
            Fdestino.DataBind();
            treqfind.Text = "";
            tserie.Text = "";
            tsalida.Text = "";
            tvice.Text = "";
            treqeq.Text = "";
        }
    }
}
