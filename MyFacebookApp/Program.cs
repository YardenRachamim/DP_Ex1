using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyFacebookApp
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
