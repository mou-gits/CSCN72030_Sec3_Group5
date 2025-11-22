using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateGUI.UI_utilities
{
    public class UiLogger
    {
        private readonly RichTextBox _logBox;
        private readonly Form _form;

        public UiLogger(Form form, RichTextBox logBox)
        {
            _form = form;
            _logBox = logBox;
        }

        public void Log(string message)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";

            if (_form.InvokeRequired)
            {
                _form.BeginInvoke(new Action(() => _logBox.AppendText(entry)));
            }
            else
            {
                _logBox.AppendText(entry);
            }
        }

        public void Clear()
        {
            if (_form.InvokeRequired)
            {
                _form.BeginInvoke(new Action(() => _logBox.Clear()));
            }
            else
            {
                _logBox.Clear();
            }
        }
    }

}
