using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatfotoWui3.Core.Contracts.Services
{
    public interface IDataService
    {
        IList<Folder> GetFolders();
        Folder GetFolder(int id);
        int AddFolder(Folder item);
        void UpdateFolder(Folder item);
        
        IList<SingleWork> GetWorks();
        SingleWork GetWork(int id);
        int AddWork(SingleWork item);
        void UpdateWork(SingleWork item);
    }
}
