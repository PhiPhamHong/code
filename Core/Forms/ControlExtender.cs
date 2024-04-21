using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Core.Extensions;
using System;
using System.Net;
using System.Net.Sockets;

namespace Core.Forms
{
    public static class ControlExtender
    {
        /// <summary>
        /// Tìm tất cả các control nằm trong xác định với Type cho trước
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static List<Control> FindControls(this Control control)
        {
            // Lấy ra  các Control thuộc cấp 1
            var controls = control.Controls.Cast<Control>();

            // Ứng với mỗi Control thuộc cấp 1 lại thực hiện tìm tiếp theo đệ quy
            return controls.Concat(controls.SelectMany(c => c.FindControls())).ToList();
        }
        public static Dictionary<string, object> GetValuesInForm(this Control control)
        {
            var controls = control.FindControls().Where(c => c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()));
            return controls.ToDictionary(c => c.Tag.ToString(), c =>
            {
                if (c is TextBox) return (c as TextBox).Text;
                else if (c is CheckBox) return (c as CheckBox).Checked;
                else if (c is IInput) return (c as IInput).GetValue();
                return (object)null;
            });
        }
        public static void FillValues(this Control control, object data, bool fillWhenNull = true)
        {
            var controls = control.FindControls().Where(c => c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()));
            controls.ForEach(c =>
            {
                var value = data.GetPropertyValue(c.Tag.ToString());
                if ((value == null && fillWhenNull) || value != null)
                {
                    if (c is TextBox) (c as TextBox).Text = Convert.ToString(value);
                    else if (c is CheckBox) (c as CheckBox).Checked = value.To<bool>();
                    else if (c is IInput) (c as IInput).SetValue(value);
                }
            });
        }
        public static void FillValues(this Control control, Dictionary<string, object> data, bool fillWhenNull = true)
        {
            var controls = control.FindControls().Where(c => c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()));
            controls.SJoin(data, c => c.Tag.ToString(), d => d.Key, (c, d) =>
            {
                var value = d.Value;
                if ((value == null && fillWhenNull) || value != null)
                {
                    if (c is TextBox) (c as TextBox).Text = Convert.ToString(value);
                    else if (c is CheckBox) (c as CheckBox).Checked = value.To<bool>();
                    else if (c is IInput) (c as IInput).SetValue(value);
                }
            });
        }
        public static T ParseTo<T>(this Control control) where T : new()
        {
            var t = new T();
            control.ParseTo(t);
            return t;
        }
        public static void ParseTo(this Control control, object obj)
        {
            var values = control.GetValuesInForm();
            obj.Parse(values, false);
        }
        public static void Alert(this Control control, string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void AlertInformation(this Control control, string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool Confirm(this Control control, string msg)
        {
            return MessageBox.Show(msg, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
        public static string GetLocalIPAddress(this Control control)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "localhost";
        }
    }
}
