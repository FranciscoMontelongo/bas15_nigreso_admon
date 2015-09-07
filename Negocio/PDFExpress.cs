using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web;
using System.IO;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing;

namespace Negocio
{
    public class PDFExpress
    {

        public void ASPXToPDF(HtmlGenericControl objhtml)
        {
            string fileName = "AsignacionFolios.pdf";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            objhtml.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());

            Document pdfDoc = new Document(PageSize.A2, 5f, 5f, 5f, 5f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();

            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }

        public void ASPXToPDF(HtmlTable objhtml1,  HtmlTable objhtml2)
        {
            string fileName = "AsignacionFolios.pdf";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            
            StringWriter sw1 = new StringWriter();
            HtmlTextWriter hw1 = new HtmlTextWriter(sw1);
            objhtml1.RenderControl(hw1);

            StringWriter sw2 = new StringWriter();
            HtmlTextWriter hw2 = new HtmlTextWriter(sw2);
            objhtml2.RenderControl(hw2);

            StringReader sr1 = new StringReader(sw1.ToString());
            StringReader sr2 = new StringReader(sw2.ToString());

            Document pdfDoc = new Document(PageSize.A2, 5f, 5f, 5f, 5f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr1);
            pdfDoc.NewPage();

            htmlparser.Parse(sr2);
            pdfDoc.Close();

            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }

    }
}

