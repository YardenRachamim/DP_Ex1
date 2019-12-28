using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Utils
{
    public static class WinFormUtils
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

        public static void ClearAllControlsFromAGivenList(Control.ControlCollection i_Controls)
        {
            foreach (Control control in i_Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                else if (control is CheckBox)
                {
                    CheckBox chkbox = (CheckBox)control;
                    chkbox.Checked = false;
                }
                else if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.Items.Clear();
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)control;
                    dtp.Value = DateTime.Now ;
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.Items.Clear();
                }
                else if (control is Button)
                {
                    Button button = (Button)control;
                    WinFormUtils.RemoveAllClickEvents(button);
                }
            }
        }
    }
}
