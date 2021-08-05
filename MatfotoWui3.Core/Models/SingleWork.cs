using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Models
{
    public class SingleWork
    {
        public int Id { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }
        public bool Selected { get; set; } = false;

        public bool IdWork { get; set; } = false;

        public int Copies1015 { get; set; }
        public int Copies1318 { get; set; }
        public int Copies1515 { get; set; }
        public int Copies1520 { get; set; }
        public int Copies2020 { get; set; }
        public int Copies2025 { get; set; }
        public int Copies2030 { get; set; }
        public int CopiesA4 { get; set; }

        public bool Border1015 { get; set; } = false;
        public bool Border1318 { get; set; } = false;
        public bool Border1515 { get; set; } = false;
        public bool Border1520 { get; set; } = false;
        public bool Border2020 { get; set; } = false;
        public bool Border2025 { get; set; } = false;
        public bool Border2030 { get; set; } = false;

        public bool BorderA4 { get; set; } = false;

        public string Acabado1015 { get; set; }
        public string Acabado1318 { get; set; }
        public string Acabado1515 { get; set; }
        public string Acabado1520 { get; set; }
        public string Acabado2020 { get; set; }
        public string Acabado2025 { get; set; }
        public string Acabado2030 { get; set; }
        public string AcabadoA4 { get; set; }

        public bool Landscape { get; set; } = false;
    }
}
