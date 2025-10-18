using System.Windows.Forms;
using System.Drawing.Printing;

namespace TicketApp
{
    partial class Form1
    {
        private Button button1;
        private ComboBox printerCombo;

        private void InitializeComponent()
        {
            // this.button1 = new Button();
            // this.SuspendLayout();

            // this.button1.Text = "Print Ticket";
            // this.button1.Location = new System.Drawing.Point(50, 50);
            // this.button1.Click += new System.EventHandler(this.button1_Click);

            // this.ClientSize = new System.Drawing.Size(200, 150);
            // this.Controls.Add(this.button1);
            // this.Text = "Ticket Queue";
            // this.ResumeLayout(false);

             this.Text = "Printer Test";
            this.Width = 300;
            this.Height = 150;

            printerCombo = new ComboBox();
            printerCombo.Left = 20;
            printerCombo.Top = 20;
            printerCombo.Width = 240;

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printerCombo.Items.Add(printer);
            }

            if (printerCombo.Items.Count > 0)
                printerCombo.SelectedIndex = 0;

            this.Controls.Add(printerCombo);
        }
    }
}
