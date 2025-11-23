using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend_csharp.Utilities;

namespace DormClimateGUI.UI_utilities
{
    public class UiLogger : ILogger
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

            Action update = () => {
                _logBox.Text = entry + _logBox.Text;
                };

            if (_form.InvokeRequired)
            {
                _form.BeginInvoke(update);
            }
            else
            {
                update();
            }
        }

        public void Clear()
        {
            Action clear = () => _logBox.Clear();

            if (_form.InvokeRequired)
            {
                _form.BeginInvoke(clear);
            }
            else
            {
                clear();
            }
        }
    }

}
