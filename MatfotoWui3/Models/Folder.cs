using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace MatfotoWui3.Models
{
    public class Folder 
    {
        public Folder(IStorageItem storageItem, string token)
        {
            FolderPath = storageItem.Path;
            FolderName = storageItem.Name;
            ImageLocation = "/Images/folder.png";
            FaToken = token;
        }

        public string FaToken { get; set; }

        public string ImageLocation { get; set; }

        public string FolderPath { get; set; }

        public string FolderName { get; set; }

        
    }
}
