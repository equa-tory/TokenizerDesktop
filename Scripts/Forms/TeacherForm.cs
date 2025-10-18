using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TicketApp
{

    public partial class TeacherForm : Form
    {
        private TicketManager ticketManager = new TicketManager();

        //--------------------------------------------------------------------------------------------

        public TeacherForm()
        {
            InitializeComponent();
            RefreshTicketList();
            SetupMenu();
        }

        private void RefreshTicketList()
        {
            ticketList.Items.Clear();
            List<Ticket> activeTickets = ticketManager.LoadTickets();
            foreach (Ticket t in activeTickets)
            {
                ticketList.Items.Add("No." + t.number.ToString("D3") + " | " + t.type + " | " + t.timestamp);
            }
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshTicketList();
        }

        private MenuStrip menuStrip;

        private void SetupMenu()
        {
            menuStrip = new MenuStrip();

            // Toolbar menu
            ToolStripMenuItem settingsMenu = new ToolStripMenuItem("Настройки");

            ToolStripMenuItem ipMenuItem = new ToolStripMenuItem("TokenizerWeb IP");
            ipMenuItem.Click += IpMenuItem_Click;

            ToolStripMenuItem timerMenuItem = new ToolStripMenuItem("Скорость очереди");
            timerMenuItem.Click += TimerMenuItem_Click;

            // ToolStripMenuItem timerMenuItem = new ToolStripMenuItem("Выбор принтера");
            // timerMenuItem.Click += TimerMenuItem_Click;

            settingsMenu.DropDownItems.Add(ipMenuItem);
            settingsMenu.DropDownItems.Add(timerMenuItem);

            menuStrip.Items.Add(settingsMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }
        private void IpMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter server IP for requests:",
                "Server IP",
                ticketManager.ServerIP, 0, 0); // current default
            if (!string.IsNullOrEmpty(input))
            {
                // Properties.Settings.Default.ServerIP = input; // TODO: read from settings
                // Properties.Settings.Default.Save();
                ticketManager.ServerIP = input;
            }
        }
        private void TimerMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter queue refresh interval in milliseconds:",
                "Queue Update Timer",
                "3000", 0, 0); // TODO: read from settings

            int ms; // declare variable here
            if (int.TryParse(input, out ms))
            {
                UpdateTimer(ms);
            }
        }






        private void NextButton_Click(object sender, EventArgs e)
        {
            Ticket next = ticketManager.CallNextTicket();

            if (next != null)
            {
                // MessageBox.Show(
                //     "Вызван билет:\n№" + next.number +
                //     "\nТип: " + next.type +
                //     "\nДата: " + next.timestamp,
                //     "Вызов студента");
            }
            else
            {
                MessageBox.Show("Очередь пуста!", "Информация");
            }

            RefreshTicketList();
        }
    }
}