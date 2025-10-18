using System;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

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
            // string dbPath = "Database\\tickets.db";
            // using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;"))
            // {
            //     conn.Open();

            //     string sql = "SELECT * FROM Tickets WHERE Called = 0 ORDER BY Id ASC LIMIT 1;";
            //     using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            //     {
            //         SQLiteDataReader reader = cmd.ExecuteReader();
            //         if (reader.Read())
            //         {
            //             string number = reader["TicketNumber"].ToString();
            //             string type = reader["TicketType"].ToString();
            //             string date = reader["CreatedAt"].ToString();

            //             System.Windows.Forms.MessageBox.Show(
            //                 "Билет №" + number + "\nТип: " + type + "\nДата: " + date,
            //                 "Информация о билете");
            //         }
            //         else
            //         {
            //             System.Windows.Forms.MessageBox.Show("Очередь пуста!", "Информация");
            //         }
            //         reader.Close();
            //     }
            // }
            TicketStorage storage = new TicketStorage();
            List<Ticket> tickets = storage.LoadTickets();
            tickets.Add(new Ticket
            {
                Number = tickets.Count + 1,
                DatePrinted = DateTime.Now,
                Called = false,
                TicketType = "ExamRetake"
            });
            storage.SaveTickets(tickets);

            Ticket last = tickets[tickets.Count - 1];
            MessageBox.Show(
                "Ticket printed (example)\n" +
                "№" + last.Number + "\n" +
                "Дата: " + last.DatePrinted + "\n" +
                "Тип: " + last.TicketType + "\n" +
                "Вызван: " + last.Called);

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
