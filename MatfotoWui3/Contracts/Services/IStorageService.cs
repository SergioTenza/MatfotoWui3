using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Contracts.Services
{
    public interface IStorageService
    {
        List<Folder> Folders { get; set; }
        List<string> Files { get; set; }
        bool AddFolder(string folderName);
        bool AddFile(string fileName, string folderName);
        bool RemoveFile(string fileName);
        bool RemoveFolder(string folderName);
    }
}
