using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace MatfotoWui3.Models
{
    public class FolderListMember
    {
        public string FolderToken { get; set; }
        public string FolderName { get; set; }

        public IList<FolderFile> FolderFiles { get; set; }

        public FolderListMember()
        {
            FolderFiles = new List<FolderFile>();
        }
    }
}