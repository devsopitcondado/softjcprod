using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Softjc.views
{
    public partial class ingseries : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SetFecha();
            SetUsername();
            if (!IsPostBack)
            {
                rmar();
                rmodel();
                rcat();
                CantPlaceHolder1.Controls.Clear();
            }
        }

        private void SetUsername()
        {
            user.Text = User.Identity.Name;
        }
        private void rcat()
        {
            models.crudcategoria rc = new models.crudcategoria();
            rc.Rcategoria(Listcategoria);
        }

        private void rmar()
        {
            models.crudmarca rmarca = new models.crudmarca();
            rmarca.Rmarca(Lismarca);
        }

        private void rmodel()
        {
            models.crudmodelo rmodelo = new models.crudmodelo();
            rmodelo.Rmodelo(Listmodelo);
        }

        DateTime datetoday;
        private void SetFecha()
        {
            models.localinf daet = new models.localinf();
            datetoday = daet.GetDateTime();
            date.Text = daet.GetDateTime().ToString();
        }

        String vacio = @"<script type='text/javascript'>
                                     alert('El campo serie no puede ir vacio');
                                </script>";

        String alerat = @"<script type='text/javascript'>
                                     alert('Favor su apoyo en seleccionar una categoria, marca o modelo no puede ir vacio');
                                </script>";


        protected void save_Click(object sender, EventArgs e)
        {

            try
            {
                int idmodelo = Int32.Parse(Listmodelo.SelectedValue);

                int idmarca = Int32.Parse(Lismarca.SelectedValue);

                int idcategoria = Int32.Parse(Listcategoria.SelectedValue);

                string estado = "INI";

                if (numserie.Text != "")
                {
                    models.crudproducto cproduc = new models.crudproducto();

                    String serie = numserie.Text;

                    String usuario = user.Text;

                    String serproduc = cproduc.Fproducto(this, serie);


                    if (serproduc != "")
                    {

                        String existe = @"<script type='text/javascript'>
                             titulo = 'Ya existe el numero de serie: {0}'
                             alert(titulo);</script>";

                        string script = string.Format(existe, serproduc);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                        numserie.Text = "";
                    }
                    else
                    {
                        cproduc.Cproducto(this, serie, idcategoria, idmarca, idmodelo, usuario, datetoday,estado);

                        numserie.Text = "";
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", alerat, false);
            }
        }

        protected void GridSerie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Chksinserie_CheckedChanged(object sender, EventArgs e)
        {

            if (Chksinserie.Checked)
            {
                validarseleccionlist();
                iCanttext.Text = "";
            }
            else
            {
                numserie.Enabled = true;
                iCant.Visible = false;
                iCanttext.Visible = false;
                cCtr.Visible = false;
                iCant.Enabled = false;
                iCanttext.Enabled = false;
                cCtr.Enabled = false;
                savecantidad.Visible = false;
                savecantidad.Enabled = false;
                save.Visible = true;
                save.Enabled = true;
            }
        }


        protected String armaseriesinserie()
        {

            string seriesinserie = "";

            try
            {

                string nommodelo = Convert.ToString(Listmodelo.SelectedItem);

                string nommarca = Convert.ToString(Lismarca.SelectedItem);

                string nomcategoria = Convert.ToString(Listcategoria.SelectedItem);

                string nomcat3 = "";

                string nomodel3 = "";

                string nommar3 = "";

                if (nommodelo != "" && nommarca != "" && nomcategoria != "")
                {
                    nomcat3 = nomcategoria.Substring(0, 2);

                    nommar3 = nommarca.Substring(0, 2);

                    nomodel3 = nommodelo.Substring(0, 2);

                    string saleatorio = "";

                    models.KeyGenerator stralea = new models.KeyGenerator();

                    saleatorio = stralea.GetUniqueKey(6);

                    seriesinserie = nomcat3 + nommar3 + nomodel3 + saleatorio;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", alerat, true);
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", alerat, false);
            }

            return seriesinserie;
        }



        private void validarseleccionlist()
        {

            string nommodelo = Convert.ToString(Listmodelo.SelectedItem);

            string nommarca = Convert.ToString(Lismarca.SelectedItem);

            string nomcategoria = Convert.ToString(Listcategoria.SelectedItem);

            if (nommodelo != "" && nommarca != "" && nomcategoria != "")
            {
                numserie.Enabled = false;
                iCant.Visible = true;
                iCanttext.Visible = true;
                cCtr.Visible = true;
                iCant.Enabled = true;
                iCanttext.Enabled = true;
                cCtr.Enabled = true;
                savecantidad.Visible = true;
                savecantidad.Enabled = true;
                save.Enabled = false;
                save.Visible = false;
            }
            else
            {
                Chksinserie.Checked = false;

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", alerat, false);
            }
        }

        static SerieDinamica objseries = new SerieDinamica();

        static List<SerieDinamica> listobjseries = new List<SerieDinamica>();

        public void CargarControles()
        {

            CantPlaceHolder1.Controls.Clear();

            string seriege = armaseriesinserie();

            int i = 0;

            int cantidad = Convert.ToInt32(iCanttext.Text);


            for (i = 1; i < cantidad + 1; i++)
            {

                Cantidad cserie = (Cantidad)LoadControl("~/views/Cantidad.ascx");

                string seriegenf = seriege + i;

                cserie.ID = "cser" + i;

                cserie.AsignarID(i, seriegenf,cantidad,CantPlaceHolder1);

                CantPlaceHolder1.Controls.Add(cserie);

                OtroAction();

            }

        }

        public void OtroAction()
        {
            SerieDinamicaTMP rC = Session["STMP"] as SerieDinamicaTMP;

            if (rC == null)
            {
                return;
            }

            string serieavalidar = rC.seriedintemp;

            listobjseries.Add(new SerieDinamica() { seriedin = serieavalidar });

        }

        protected void cCtr_Click(object sender, EventArgs e)
        {
            CargarControles();
        }

        
        protected void savecantidad_Click(object sender, EventArgs e)
        {
            try
            {
                int idmodelo = Int32.Parse(Listmodelo.SelectedValue);

                int idmarca = Int32.Parse(Lismarca.SelectedValue);

                int idcategoria = Int32.Parse(Listcategoria.SelectedValue);

                models.crudproducto cproduc = new models.crudproducto();

                String usuario = user.Text;

                string estado = "INI";

                foreach (SerieDinamica aPart in listobjseries)
                {
                    cproduc.Cproducto(this, aPart.seriedin, idcategoria, idmarca, idmodelo, usuario, datetoday,estado);
                }

                iCanttext.Text = "";
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", alerat, false);
            }
        }
    }
}
