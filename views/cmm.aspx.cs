using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.views
{
    public partial class CMM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetFecha();
            SetUsername();
        }
        String vacio = @"<script type='text/javascript'>
                             alert('El campo no puede ir vacio');
                        </script>";




        public void SetUsername()
        {
            user.Text = User.Identity.Name;
        }

        DateTime dateT;

        public void SetFecha()
        {
            models.localinf dat = new models.localinf();
            date.Text = dat.GetDateTime().ToString();
            dateT = dat.GetDateTime();
        }

        protected void bsavecategoria_Click(object sender, EventArgs e)
        {
            if (tcategoria.Text != "")
            {
                models.crudcategoria cmm = new models.crudcategoria();

                String categoria = tcategoria.Text;

                String cate = cmm.Fcategoria(this, categoria);

                if (cate != "")
                {
                    String existe = @"<script type='text/javascript'>
                             titulo = 'Ya existe la categoria: {0}'
                             alert(titulo);</script>";

                    string script = string.Format(existe, cate);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                    tcategoria.Text = "";
                }
                else
                {
                    String nomusuario = user.Text;

                    String estado = "Activo";

                    cmm.Ccat(this, categoria, nomusuario, estado, dateT);

                    tcategoria.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }
        }

        protected void bsavemodelo_Click(object sender, EventArgs e)
        {
            if (tmodelo.Text != "")
            {
                models.crudmodelo cmmod = new models.crudmodelo();

                String modelo = tmodelo.Text;

                String model = cmmod.Fmodelo(this, modelo);

                if (model != "")
                {
                    String existe = @"<script type='text/javascript'>
                             titulo = 'Ya existe el modelo: {0}'
                             alert(titulo);</script>";

                    string script = string.Format(existe, model);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                    tmodelo.Text = "";
                }
                else
                {
                    String nomusuario = user.Text;

                    String estado = "Activo";

                    cmmod.Cmod(this, modelo, nomusuario, estado, dateT);

                    tmodelo.Text = "";
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }
        }

        protected void bsavemarca_Click(object sender, EventArgs e)
        {
            if (tmarca.Text != "")
            {
                models.crudmarca cmm = new models.crudmarca();

                String marca = tmarca.Text;

                String marc = cmm.Fmarca(this, marca);

                if (marc != "")
                {
                    String existe = @"<script type='text/javascript'>
                             titulo = 'Ya existe la marca: {0}'
                             alert(titulo);</script>";

                    string script = string.Format(existe, marc);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                    tmarca.Text = "";
                }
                else
                {
                    String nomusuario = user.Text;

                    String estado = "Activo";

                    cmm.Cmar(this, marca, nomusuario, estado, dateT);


                    tmarca.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }

        }
    }
}
