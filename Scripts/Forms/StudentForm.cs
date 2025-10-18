using System;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class StudentForm : Form
    {
        private bool isFullScreen = false;
        private FormBorderStyle previousFormBorderStyle;
        private System.Drawing.Rectangle previousBounds;

        //--------------------------------------------------------------------------------------------

        public StudentForm()
        {
            InitializeComponent();
            this.KeyPreview = true; // чтобы ловить клавиши на форме
            this.KeyDown += Form_KeyDown;
        }

        //--------------------------------------------------------------------------------------------

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                ToggleFullScreen();
            }
        }

        private void ToggleFullScreen()
        {
            if (!isFullScreen)
            {
                previousFormBorderStyle = this.FormBorderStyle;
                previousBounds = this.Bounds;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                isFullScreen = true;
            }
            else
            {
                this.FormBorderStyle = previousFormBorderStyle;
                this.Bounds = previousBounds;

                isFullScreen = false;
            }
        }
    }
}
