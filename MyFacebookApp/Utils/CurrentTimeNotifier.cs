using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class CurrentTimeNotifier
    {
        public static event Action<DateTime> Notifier;

        public static void NotifyCurrentTime()
        {
            Debug.WriteLine("Notify!");

            if (Notifier != null)
            {
                DateTime dt = DateTime.Now;
                Notifier.Invoke(dt);
            }
        }
    }
}
