using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Utils
{
    public class WinFormUtils
    {
        public static void RemoveAllClickEvents(Button i_Button)
        {
            FieldInfo fieldInfo = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = fieldInfo.GetValue(i_Button);
            PropertyInfo propertyInfo = i_Button.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)propertyInfo.GetValue(i_Button, null);

            list.RemoveHandler(obj, list[obj]);
        }
    }
}
