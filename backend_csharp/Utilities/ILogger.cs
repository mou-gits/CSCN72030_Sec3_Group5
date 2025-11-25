using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_csharp.Utilities
{
    public interface ILogger
    {
        void Log(string message);
        void Clear();
    }
}
