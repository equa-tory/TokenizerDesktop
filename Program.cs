using System;
using System.Windows.Forms;

namespace TicketApp
{
    static class Program
    {

        // public MainForm()
        // {
        //     this.Text = "Printer Test";
        //     this.Width = 300;
        //     this.Height = 150;

        //     printerCombo = new ComboBox();
        //     printerCombo.Left = 20;
        //     printerCombo.Top = 20;
        //     printerCombo.Width = 240;

        //     foreach (string printer in PrinterSettings.InstalledPrinters)
        //     {
        //         printerCombo.Items.Add(printer);
        //     }

        //     if (printerCombo.Items.Count > 0)
        //         printerCombo.SelectedIndex = 0;

        //     this.Controls.Add(printerCombo);
        // }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
