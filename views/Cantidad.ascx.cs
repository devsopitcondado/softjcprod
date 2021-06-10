using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.views
{
    public partial class Cantidad : System.Web.UI.UserControl
    {


        SerieDinamicaTMP lserdintmp;

        List<SerieDinamicaTMP> lseriesdintmp;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public Cantidad()
        {
            lserdintmp = new SerieDinamicaTMP();

            lseriesdintmp = new List<SerieDinamicaTMP>();
        }
        public void AsignarID(int num, string seriegenerada, int cantidad, PlaceHolder CantPlaceHolder1)
        {

            Session["STMP"] = null;

            string idtexto = "tcserie" + num;

            string serietexto = seriegenerada;

            cserietext.ID = idtexto;

            cserietext.Text = serietexto;

            lserdintmp.seriedintemp = serietexto;

            lseriesdintmp.Add(lserdintmp);

            Session["STMP"] = lserdintmp;
        }


        
    }
}