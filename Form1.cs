using System;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Printing;

namespace TicketApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketStorage storage = new TicketStorage();
            List<Ticket> tickets = storage.LoadTickets();

            // добавить новый билет
            Ticket t = new Ticket();
            t.Number = tickets.Count + 1;
            t.DatePrinted = DateTime.Now;
            t.Called = false;
            t.TicketType = "ExamRetake";
            tickets.Add(t);
            storage.SaveTickets(tickets);

            // вывести все билеты
            string all = "Все билеты:\n\n";
            foreach (Ticket item in tickets)
            {
                all += "№" + item.Number +
                    " | Тип: " + item.TicketType +
                    " | Дата: " + item.DatePrinted +
                    " | Вызван: " + (item.Called ? "Да" : "Нет") +
                    "\n";
            }

            MessageBox.Show(all, "Список билетов");


            SoundPlayer player = new SoundPlayer(@"Audio\accept.wav");
            player.PlaySync();
            player = new SoundPlayer(@"Audio\welcome.wav");
            player.PlaySync();
            player = new SoundPlayer(@"Audio\0-1.wav");
            player.PlaySync();
            player = new SoundPlayer(@"Audio\0-2.wav");
            player.PlaySync();
            player = new SoundPlayer(@"Audio\7.wav");
            player.Play();
        }
    }
}
