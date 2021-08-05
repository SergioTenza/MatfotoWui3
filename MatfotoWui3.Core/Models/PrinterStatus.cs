using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Models
{
    public class PrinterStatus
    {
        public string PrinterName { get; set; }
        public string PrinterState { get; set; }
        public string PrinterPortName { get; set; }
        public int PrinterPortNumber { get; set; }
        public int PrinterTotalLifePrints { get; set; }
        public int PrinterLeftMedia { get; set; }
        public string PrinterFirmware { get; set; }

    }
}
