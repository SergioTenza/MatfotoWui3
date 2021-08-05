using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Models
{
    public class Folder
    {
        public int Id { get; set; }

        public string ImageLocation { get; set; }

        public string FolderPath { get; set; }

        public string FolderName { get; set; }

        public IList<string> FolderFiles { get; set; }
    }
}
