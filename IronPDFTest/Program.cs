using IronPdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace IronPDFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get some pdfs from the root project folder
            var docs = new List<string>
            {
                "../../../Wikipedia.pdf",
                "../../../The C# PDF Library _ Iron PDF.pdf"
            };

            // Create Renderer for generating cover sheet from HTML
            var Renderer = new HtmlToPdf
            {
                PrintOptions = new PdfPrintOptions
                {
                    CssMediaType = PdfPrintOptions.PdfCssMediaType.Print                    
                },
            };

            // First page is a coversheet containing some meta-data about the attached documents
            var coverSheet = Renderer.RenderHtmlAsPdf("<h1>This is my cover page</h1>");
            var pdfList = new List<PdfDocument>
            {
                coverSheet
            };

            // Additional PDFs need to be attached
            foreach (var doc in docs)
            {
                pdfList.Add(PdfDocument.FromFile(doc));
            }

            PdfDocument pdf = PdfDocument.Merge(pdfList);

            pdf.SaveAs("../../../MergeTest.pdf");
        }
    }
}
