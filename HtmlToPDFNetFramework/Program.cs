using PdfSharp.Pdf;
using System;
using System.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace HTMLtoPDF
{
    internal class Program
    {
        static public void Main(String[] args)
        {

            if (args == null)
            {
                Console.WriteLine("Missing arguments");
                return;
            } else
            {
                Console.WriteLine("Passing in: " + args[0]);
                String sourcePath = args[0];
                String destinationPath = args[1];


                String html = File.ReadAllText(sourcePath);

                Byte[] rawData = convertHTMLtoPDF(html.Replace('"', '\"'), destinationPath);
            }
            Console.WriteLine("Conversion complete");
            Console.Read();
        }

        public static Byte[] convertHTMLtoPDF(String html, String dest)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                //pdf.Save(@"C:\Users\brend\Documents\PDF\test.pdf");
                pdf.Save(@dest);
                res = ms.ToArray();
                
            }

            return res;
        }
    }


}