using System.Windows.Forms;

namespace TicketApp
{
    partial class Form1
    {
        private Button button1;

        private void InitializeComponent()
        {
            this.button1 = new Button();
            this.SuspendLayout();

            this.button1.Text = "Print Ticket";
            this.button1.Location = new System.Drawing.Point(50, 50);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            this.ClientSize = new System.Drawing.Size(200, 150);
            this.Controls.Add(this.button1);
            this.Text = "Ticket Queue";
            this.ResumeLayout(false);
        }
    }
}
