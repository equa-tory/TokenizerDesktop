using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TicketApp
{
    class PrinterManager
    {
        private string printerName;

        public PrinterManager(string printer)
        {
            printerName = printer;
        }

        public void PrintTicket(Ticket ticket)
        {
            try
            {
                PrintDocument doc = new PrintDocument();
                doc.PrinterSettings.PrinterName = printerName;

                doc.PrintPage += delegate (object sender, PrintPageEventArgs e)
                {
                    // Simple text ticket layout
                    Font bigFont = new Font("Arial", 69, FontStyle.Bold);
                    Font font = new Font("Arial", 14, FontStyle.Bold);
                    Font smallFont = new Font("Arial", 10);
                    float y = 20;

                    // e.Graphics.DrawString("Билет", font, Brushes.Black, 10, y); y += 30;
                    // e.Graphics.DrawString("Номер: " + ticket.number.ToString("D3"), smallFont, Brushes.Black, 10, y); y += 20;
                    // e.Graphics.DrawString("Тип: " + ticket.type, smallFont, Brushes.Black, 10, y); y += 20;
                    // e.Graphics.DrawString("Дата: " + ticket.timestamp.ToString("dd.MM.yyyy HH:mm"), smallFont, Brushes.Black, 10, y);

                    // y += 30;
                    // e.Graphics.DrawString("--------------------------", smallFont, Brushes.Black, 10, y);

                    e.Graphics.DrawString(ticket.type, font, Brushes.Black, 10, y); y += 40;
                    e.Graphics.DrawString("Ваш номер очереди:", font, Brushes.Black, 10, y); y += 30;
                    e.Graphics.DrawString(ticket.number.ToString("D3"), bigFont, Brushes.Black, 10, y); y += 100;
                    e.Graphics.DrawString("Дата и время выдачи талона:", smallFont, Brushes.Black, 10, y); y += 20;
                    e.Graphics.DrawString(ticket.timestamp.ToString("dd.MM.yyyy HH:mm"), smallFont, Brushes.Black, 35, y);
                };

                ///Print method
                doc.Print();

                ///Print preview
                // PrintPreviewDialog preview = new PrintPreviewDialog();
                // preview.Document = doc;
                // preview.ShowDialog();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Ошибка при печати: " + ex.Message);
            }
        }
    }
}