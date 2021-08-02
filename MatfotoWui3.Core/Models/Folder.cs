using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Models
{
    public class Folder
    {
        public string FolderPath { get; set; }

        public ICollection<string> FolderFiles { get; set; }
    }
}
