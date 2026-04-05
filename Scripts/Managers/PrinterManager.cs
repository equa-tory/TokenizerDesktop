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

        public void PrintTicket(Ticket ticket, bool printDebug)
        {
            if (printerName == "None") return;

            try
            {
                PrintDocument doc = new PrintDocument();
                doc.PrinterSettings.PrinterName = printerName;

                doc.PrintPage += delegate (object sender, PrintPageEventArgs e)
                {
                    float y = 20;

                    // === CONFIG ===
                    Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                    Font numberFont = new Font("Arial", 40, FontStyle.Bold);
                    Font smallFont = new Font("Arial", 10);

                    string headerText = "Ваш номер очереди:";
                    string numberText = !string.IsNullOrEmpty(ticket.displayNumber)
                        ? ticket.displayNumber
                        : ticket.number.ToString("D3");

                    string dateLabel = "Дата и время:";
                    string dateText = ticket.timestamp.ToString("dd.MM.yyyy HH:mm");

                    // === PRINT ===
                    e.Graphics.DrawString(headerText, headerFont, Brushes.Black, 10, y);
                    y += 40;

                    e.Graphics.DrawString(numberText, numberFont, Brushes.Black, 10, y);
                    y += 80;

                    e.Graphics.DrawString(dateLabel, smallFont, Brushes.Black, 10, y);
                    y += 20;

                    e.Graphics.DrawString(dateText, smallFont, Brushes.Black, 10, y);

                };

                if(printDebug == true){

                    PrintPreviewDialog preview = new PrintPreviewDialog();
                    preview.Document = doc;
                    preview.Width = 800;
                    preview.Height = 600;
                    preview.ShowDialog();
                }
                else
                {
                    doc.Print();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}