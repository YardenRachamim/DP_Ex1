using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace MyFacebookApp
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            runServer();
            MainForm maimForm = new MainForm();
        }

        private static void runServer()
        {
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromSeconds(10);

            System.Threading.Timer timer = new System.Threading.Timer((e) =>
            {
                CurrentTimeNotifier.NotifyCurrentTime();
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}
