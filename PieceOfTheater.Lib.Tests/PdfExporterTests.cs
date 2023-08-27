using PieceofTheater.Lib.Model;
using PieceOfTheater.Lib.ExportPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceOfTheater.Lib.Tests
{
    public class PdfExporterTests
    {
        [Test]
        public void PdfExporterTest_Test()
        {
            PdfExporter pdf = new PdfExporter();
            pdf.Test();
        }
    }
}
