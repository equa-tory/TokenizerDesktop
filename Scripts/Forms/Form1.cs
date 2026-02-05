using System;
using System.Windows.Forms;

namespace TicketApp
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class ScriptManager
    {
        public void ButtonClicked()
        {
            MessageBox.Show("Button clicked from HTML!");
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            WebBrowser browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);

            browser.ObjectForScripting = new ScriptManager();
            browser.Url = new Uri("file:///" + Application.StartupPath + @"\Resources\Pages\test.html");
        }
    }
}
