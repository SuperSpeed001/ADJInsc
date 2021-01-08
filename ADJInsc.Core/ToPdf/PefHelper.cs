namespace ADJInsc.Core.ToPdf
{
    using ADJInsc.Models.ViewModels;
  
    using Microsoft.AspNetCore.Http;
    using System.IO;

    public class PefHelper
    {
        public PefHelper()
        {

        }
        /*
        public HttpResponse Response { get; set; }
        public void GenerarPdf(InscViewModel model)
        {
            MemoryStream ms = new MemoryStream();
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, ms);
            pdfDoc.Open();

            Chunk chunk = new Chunk("Pre Inscripción en Instituto de Vivienda de Jujuy", FontFactory.GetFont("Arial", 20, Font.BOLDITALIC, BaseColor.BLUE));
            pdfDoc.Add(chunk);

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            //Table
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell no 1
            PdfPCell cell = new PdfPCell();
            cell.Border = 0;
            Image image = Image.GetInstance(Server.MapPath("~/Content/Upload/salma.jpg"));
            image.ScaleAbsolute(200, 150);
            cell.AddElement(image);
            table.AddCell(cell);

            //Cell no 2
            chunk = new Chunk("Name: Mrs. Salma Mukherji,\nAddress: Latham Village, Latham, New York, US, \nOccupation: Nurse, \nAge: 35 years", FontFactory.GetFont("Arial", 15, Font.NORMAL, BaseColor.PINK));
            cell = new PdfPCell();
            cell.Border = 0;
            cell.AddElement(chunk);
            table.AddCell(cell);

            //Add table to document    
            pdfDoc.Add(table);

            Paragraph para = new Paragraph();
            para.Add("Hello Salma,\n\nThank you for being our valuable customer. We hope our letter finds you in the best of health and wealth.\n\nYours Sincerely, \nBank of America");
            pdfDoc.Add(para);

            //Table
            table = new PdfPTable(5);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell
            cell = new PdfPCell();
            chunk = new Chunk("This Month's Transactions of your Credit Card");
            cell.AddElement(chunk);
            cell.Colspan = 5;
            cell.BackgroundColor = BaseColor.PINK;
            table.AddCell(cell);

            table.AddCell("S.No");
            table.AddCell("NYC Junction");
            table.AddCell("Item");
            table.AddCell("Cost");
            table.AddCell("Date");

            table.AddCell("1");
            table.AddCell("David Food Store");
            table.AddCell("Fruits & Vegetables");
            table.AddCell("$100.00");
            table.AddCell("June 1");

            table.AddCell("2");
            table.AddCell("Child Store");
            table.AddCell("Diaper Pack");
            table.AddCell("$6.00");
            table.AddCell("June 9");

            table.AddCell("3");
            table.AddCell("Punjabi Restaurant");
            table.AddCell("Dinner");
            table.AddCell("$29.00");
            table.AddCell("June 15");

            table.AddCell("4");
            table.AddCell("Wallmart Albany");
            table.AddCell("Grocery");
            table.AddCell("$299.50");
            table.AddCell("June 25");

            table.AddCell("5");
            table.AddCell("Singh Drugs");
            table.AddCell("Back Pain Tablets");
            table.AddCell("$14.99");
            table.AddCell("June 28");

            //Add table to document
            pdfDoc.Add(table);

            Paragraph para2 = new Paragraph();
            para.Add("Hello Salma,\n\nThank you for being our valuable customer. We hope our letter finds you in the best of health and wealth.\n\nYours Sincerely, \nBank of America");
            pdfDoc.Add(para);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            byte[] content = ms.ToArray();
            
            
            Response.ContentType = "application/pdf";
            Response.Headers.Add("content-disposition", "attachment;filename=Credit-Card-Report.pdf");
            Response.WriteAsync(pdfDoc.ToString());
            
            
            
        }

        */
    }
}
