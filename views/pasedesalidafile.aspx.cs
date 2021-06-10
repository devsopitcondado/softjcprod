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
    public partial class pasedesalidafile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExportToPDF_RD();
            }

        }



        private static void ExportToPDF_RD()
        {
            String exportPath = "C:\\Pase\\";

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

            cryReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath + "PasedeSalida.pdf");

            cryReportDocument.Dispose();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /* Controlador.Consultas pasesalfile = new Controlador.Consultas();

             String idpasesalstr = pasesalfile.Fidpasesalida();

             int idpasesalin = Int32.Parse(idpasesalstr);

             /*CRV1PST objReporte = new CRV1PST();

             string reportPath = System.Web.HttpContext.Current.Server.MapPath("~/CRV1PST.rpt");

             //string imgpath = System.Web.HttpContext.Current.Server.MapPath("~/Imagenes/LOGO_ICASA_APP_2.jpg");

             //objReporte.Refresh();

             objReporte.SetParameterValue("@num_pase", idpasesalin);

             //objReporte.SetParameterValue("picturePath", imgpath);
             /*ReportDocument Rel = new ReportDocument();

             Rel.Load(reportPath);

             BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));

             Response.ClearContent();

             Response.ClearHeaders();

             Response.ContentType = "application/pdf";

             Response.AddHeader("content-disposition", "attachment; filename=" + downloadAsFilename);

             Response.AddHeader("content-length", stream.BaseStream.Length.ToString());

             Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));

             Response.Flush();

             Response.Close();
             //CRV1PS.ReportSource = objReporte;*/


            /*ReportDocument Rel = new ReportDocument();
            Rel.Load(reportPath);
            BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            Response.Flush();
            Response.Close();*/


            //EventLog.WriteEntry(sSource, "Iniciando proceso para archivo: " + dr["XMLOriginal"].ToString());
            /*string reportPath = System.Web.HttpContext.Current.Server.MapPath("~/CRV1PST.rpt");

            ReportDocument cryReportDocument = new ReportDocument();
            
            cryReportDocument.Load(reportPath);
            
            /*cryReportDocument.SetDatabaseLogon(usuarioBD, passBD, servidorBD, nombreBD);
            cryReportDocument.SetParameterValue("DocKey@", iDocEntry);
            cryReportDocument.SetParameterValue("Cadena@", Cadena);*/

            /* cryReportDocument.SetParameterValue("@num_pase", idpasesalin);

             cryReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:\SAP\PasedeSalida.PDF");
             //cryReportDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"c:\SAP\Archivo.PDF");
             cryReportDocument.Dispose();
             //EventLog.WriteEntry(sSource, "XML y PDF Creados");*/
        }
    }
}
