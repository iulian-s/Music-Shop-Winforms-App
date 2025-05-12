using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using ProiectPAOO.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ProiectPAOO.Models
{
    internal class PdfExporter
    {
        public void ExportCartToPdf(List<Models.ShoppingCart> cart, string username, string shippingAddress, string filePath, decimal price)
        {
            var document = new PdfDocument();
            document.Info.Title = "Order Receipt";
            var repo = new InstrumentRepository();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
            XFont headerFont = new XFont("Verdana", 14, XFontStyle.Bold);

            double y = 40;

            gfx.DrawString("Order Receipt", headerFont, XBrushes.Black, new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);
            y += 40;

            gfx.DrawString($"Customer: {username}", font, XBrushes.Black, 40, y);
            y += 20;
            gfx.DrawString($"Provider: Music Shop Galati SRL", font, XBrushes.Black, 40, y);
            y += 20;
            gfx.DrawString($"Shipping Address: {shippingAddress}", font, XBrushes.Black, 40, y);
            y += 30;

            gfx.DrawString("Items:", headerFont, XBrushes.Black, 40, y);
            y += 25;

            decimal total = 0;

            foreach (var item in cart)
            {
                var instrument = repo.GetInstrumentById(item.InstrumentId);
                decimal itemTotal = instrument.Price * item.Quantity;
                total += itemTotal;

                string line = $"{instrument.Brand + " " + instrument.Name} - Quantity: {item.Quantity} - Price: {instrument.Price} $";
                gfx.DrawString(line, font, XBrushes.Black, 50, y);
                y += 20;
            }
            y += 20;
            gfx.DrawString($"Price: ${price}", headerFont, XBrushes.Black, 50, y);
            string filename = filePath;
            document.Save(filename);
            Process.Start("explorer", filename);
        }
    }

}
