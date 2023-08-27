using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Xml.Linq;

namespace PieceOfTheater.Lib.ExportPdf
{
    public class PdfExporter
    {
        public void Test()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF1cWGhAYVBpR2NbfE5zflBOal9TVAciSV9jS31TfkdkWXxbeHdXRWZVVw==");
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document.
                PdfPage page = document.Pages.Add();
                //Create PDF graphics for a page.
                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                //Draw the text.
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
                //Save the document.
                document.Save("Output.pdf");
            }
        }
    }
}
