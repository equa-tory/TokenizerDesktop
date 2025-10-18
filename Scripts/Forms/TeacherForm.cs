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
        }

        private void RefreshTicketList()
        {
            ticketList.Items.Clear();
            List<Ticket> activeTickets = ticketManager.LoadTickets();
            foreach (Ticket t in activeTickets)
            {
                ticketList.Items.Add("№" + t.number.ToString("D3") + " | " + t.type + " | " + t.timestamp);
            }
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshTicketList();
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