using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;
using TicketApp.Managers;

namespace TicketApp
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class ScriptManager
    {
        /// <summary>
        /// Called from HTML/JS: returns JSON string of ticket types from API.
        /// </summary>
        public string GetTicketTypes()
        {
            try
            {
                return ApiManager.GetTicketTypes();
            }
            catch (Exception ex)
            {
                return "{\"error\":\"" + ex.Message.Replace("\"", "'") + "\"}";
            }
        }

        /// <summary>
        /// Returns JSON array of installed printer names (for dropdown).
        /// </summary>
        public string GetPrinters()
        {
            try
            {
                List<string> names = new List<string>();
                foreach (string name in PrinterSettings.InstalledPrinters)
                    names.Add(name);
                return Newtonsoft.Json.JsonConvert.SerializeObject(names);
            }
            catch
            {
                return "[]";
            }
        }

        /// <summary>
        /// Called when user clicks a ticket type: prints ticket to chosen printer.
        /// </summary>
        public void BookTicket(string typeId, string title, string printerName)
        {
            if (string.IsNullOrEmpty(printerName) || printerName == "None")
                return;
            Ticket ticket = new Ticket();
            ticket.type = title ?? typeId;
            ticket.number = 0;
            ticket.timestamp = DateTime.Now;
            PrinterManager pm = new PrinterManager(printerName);
            pm.PrintTicket(ticket);
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
            browser.Url = new Uri("file:///" + Application.StartupPath + @"\Resources\Pages\buttons.html");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate(object s, DoWorkEventArgs ev)
            {
                try
                {
                    ev.Result = ApiManager.GetTicketTypes();
                }
                catch (Exception ex)
                {
                    ev.Result = "Error: " + ex.Message;
                }
            };
            worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs ev)
            {
                if (ev.Error != null)
                    MessageBox.Show("Test request failed: " + ev.Error.Message, "API Test");
                else
                    MessageBox.Show("API test OK. Response:\r\n" + (ev.Result != null ? ev.Result.ToString() : ""), "API Test");
            };
            worker.RunWorkerAsync();
        }
    }
}
