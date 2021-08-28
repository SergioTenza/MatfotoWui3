using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace MatfotoWui3.Models
{
    public class FolderFile
    {
        public StorageItemThumbnail Thumb { get; set; }
        public StorageFile File { get; set; }
    }
}
