using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MatfotoWui3.Contracts.Services
{
    public interface IPickFolderService
    {
        Task<IStorageItem> GetSelectedFolderAsync();
    }
}
