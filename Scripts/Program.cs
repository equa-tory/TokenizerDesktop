using System;
using System.Windows.Forms;

namespace TicketApp
{
    static class Program
    {
#if STUDENT
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StudentForm());
        }
#endif

#if TEACHER
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TeacherForm());
        }
#endif

    }
}
