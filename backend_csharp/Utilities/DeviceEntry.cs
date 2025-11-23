using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_csharp.Utilities
{
    public class DeviceEntry
    {
        public string Id { get; set; }           // Hex Bluetooth address (e.g., 75758D9275EE)
        public string Display { get; set; }      // e.g., "Galaxy A03s (75758D9275EE)"

        public override string ToString() => Display; // What ComboBox shows
    }
}
