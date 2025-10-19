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
            this.refreshTimer.Interval = AppConfig.UpdateTimer;
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            this.refreshTimer.Start();

            ticketList = new System.Windows.Forms.ListBox(); // TODO: range select delete
            callButton = new System.Windows.Forms.Button();
            SuspendLayout();

            // Ticket List
            ticketList.FormattingEnabled = true;
            ticketList.Location = new System.Drawing.Point(10, 30);
            ticketList.Name = "ticketList";
            ticketList.Size = new System.Drawing.Size(360, 199);
            ticketList.TabIndex = 0;
            ticketList.SelectionMode = SelectionMode.MultiExtended;

            // Next Button
            callButton.Location = new System.Drawing.Point(10, 230);
            callButton.Name = "callButton";
            callButton.Size = new System.Drawing.Size(360, 30);
            callButton.TabIndex = 1;
            callButton.Text = "Следующий";
            callButton.UseVisualStyleBackColor = true;
            callButton.Click += new System.EventHandler(this.NextButton_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 261);
            Controls.Add(callButton);
            Controls.Add(ticketList);
            Name = "Queue";
            Text = "Queue";

            // Context menu
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem skipItem = new ToolStripMenuItem("Пропустить выбранные");
            skipItem.Click += new System.EventHandler(SkipSelected_Click);
            contextMenu.Items.Add(skipItem);

            contextMenu.Opening += ContextToggle;
            contextMenu.Closed += ContextToggle;

            ticketList.ContextMenuStrip = contextMenu;

            ResumeLayout(false);
        }

        public void UpdateTimer(int ms)
        {
            refreshTimer.Interval = ms;
        }
    }
}