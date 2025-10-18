using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections.Generic;

namespace TicketApp
{
    partial class StudentForm
    {
        private FlowLayoutPanel panel;
        private List<Button> buttons = new List<Button>();

        private void InitializeComponent()
        {
            this.Text = "StudentForm";

            panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.WrapContents = true;
            panel.Padding = new Padding(10);
            panel.AutoSize = true;
            panel.BackColor = Color.WhiteSmoke;

            foreach (string type in ticketTypes)
            {
                Button btn = new Button();
                btn.Text = type;
                btn.Width = 250;
                btn.Height = 50;
                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btn.BackColor = Color.LightSteelBlue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Margin = new Padding(5);

                btn.Tag = type;

                // Assign event handler dynamically
                btn.Click += new System.EventHandler(this.TicketButton_Click);

                // Add to panel and list for reference
                this.panel.Controls.Add(btn);
            }
            this.Controls.Add(this.panel);
        }
    }
}