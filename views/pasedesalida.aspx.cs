using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Softjc.views
{
    public partial class pasedesalida : System.Web.UI.Page
    {

        String vacioticktet = @"<script type='text/javascript'>
                                     alert('El campo ticket no puede ir vacio');
                                </script>";

        String vacio = @"<script type='text/javascript'>
                                     alert('Uno de los campos no puede ir vacio');
                                </script>";
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUsername();
            SetFecha();
        }


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

        protected void find_Click(object sender, EventArgs e)
        {
            models.crudsalida detailsalida = new models.crudsalida();

            String fticket = tticket.Text;

            detailsalida.Fdetailsalida(GridDetailSalida, fticket);
        }

        protected void finalizar_Click(object sender, EventArgs e)
        {
           try 
            
            { 

            models.crudsalida pasesalida = new models.crudsalida();

            String usrio = user.Text;

            String descri = tdescripcion.Text;

            String recp = treceptor.Text;

            String numdpi = tdpi.Text;

            int tnticket = Convert.ToInt32(tticket.Text);

            if (user.Text != "" && tdescripcion.Text != "" && treceptor.Text != "" && tdpi.Text != "" && tticket.Text != "")
            {
                pasesalida.Cpasesalida(this, descri, usrio, recp, numdpi, tnticket, datetoday);

                ExportToPDF_PSALIDA();

                GridDetailSalida.DataBind();

                user.Text = "";

                tdescripcion.Text = "";

                treceptor.Text = "";

                tdpi.Text = "";

                tticket.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacio, false);
            }
           }
            catch
           {
           ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", vacioticktet, false);
           }
        }

        private static void ExportToPDF_PSALIDA()
        {
            String exportPath = "C:\\Pase\\";

            String exportPathCopy = "\\SDCCORPINV\\PasesDeSalida";

            if (!System.IO.Directory.Exists(exportPath))
            {
                System.IO.Directory.CreateDirectory(exportPath);
            }

            models.crudsalida pasesalfile = new models.crudsalida();

            String idpasesalstr = pasesalfile.Fidpasesalida();

            int idpasesalin = Int32.Parse(idpasesalstr);
            

            string reportPath = System.Web.HttpContext.Current.Server.MapPath("~/CRV1PST.rpt");

            ReportDocument cryReportDocument = new ReportDocument();

            cryReportDocument.Load(reportPath);

            cryReportDocument.SetParameterValue("@num_pase", idpasesalin);

            string reportnumber = "Pasedesalida" + idpasesalin + ".pdf";

            cryReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath + reportnumber);

            //cryReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, exportPathCopy + reportnumber);

            cryReportDocument.Dispose();
        }
    }
}