using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Models
{
    public class SettingsImpresion
    {
        public short PaperSize { get; set; }
        public int OvercoatFinish { get; set; }
        public int Border { get; set; }
        public short Orientation { get; set; } = 2;
        public int PrintQuality { get; set; } = 0;
        public int Sharpness { get; set; } = 2;
        public int ICMMethod { get; set; } = 1;
        public int ColorAdjustment { get; set; } = 0;
        public int AdjGammaR { get; set; } = 0;
        public int AdjGammaG { get; set; } = 0;
        public int AdjGammaB { get; set; } = 0;
        public int AdjBrightnessR { get; set; } = 0;
        public int AdjBrightnessG { get; set; } = 0;
        public int AdjBrightnessB { get; set; } = 0;
        public int AdjContrastR { get; set; } = 0;
        public int AdjContrastG { get; set; } = 0;
        public int AdjContrastB { get; set; } = 0;
        public int AdjChromaR { get; set; } = 0;
        public int AdjChromaG { get; set; } = 0;
        public int AdjChromaB { get; set; } = 0;
        public int PrintRetry { get; set; } = 0;
        public int Cut2inch { get; set; } = 0;
    }
}
