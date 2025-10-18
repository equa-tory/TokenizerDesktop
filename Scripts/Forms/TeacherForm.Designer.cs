using System.Windows.Forms;

namespace TicketApp
{

    partial class TeacherForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox ticketList;
        private Button callButton;
        private System.Windows.Forms.Timer refreshTimer;

        //--------------------------------------------------------------------------------------------

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Timer
            this.refreshTimer = new System.Windows.Forms.Timer();
            this.refreshTimer.Interval = 3000; // every 3 seconds
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            this.refreshTimer.Start();

            ticketList = new System.Windows.Forms.ListBox();
            callButton = new System.Windows.Forms.Button();
            SuspendLayout();

            ticketList.FormattingEnabled = true;
            ticketList.Location = new System.Drawing.Point(10, 10);
            ticketList.Name = "ticketList";
            ticketList.Size = new System.Drawing.Size(360, 199);
            ticketList.TabIndex = 0;

            callButton.Location = new System.Drawing.Point(10, 220);
            callButton.Name = "callButton";
            callButton.Size = new System.Drawing.Size(360, 30);
            callButton.TabIndex = 1;
            callButton.Text = "Вызвать следующий";
            callButton.UseVisualStyleBackColor = true;
            callButton.Click += new System.EventHandler(this.NextButton_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 261);
            Controls.Add(callButton);
            Controls.Add(ticketList);
            Name = "TeacherForm";
            Text = "Queue";
            ResumeLayout(false);
        }
    }
}