using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Models
{
    public class Printer
    {
        public string PrinterName { get; set; }

        public string PortName { get; set; }

        public int PortNumber { get; set; }

        public int TotalLifeMedia { get; set; }

        public int FullLeftMedia { get; set; }

        public int HalfLeftMedia { get; set; }
    }
}
