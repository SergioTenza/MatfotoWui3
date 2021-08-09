using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;

namespace MatfotoWui3.Helpers
{
    public static class StorageFolderHelpers
    {
        public static async Task<StorageFolder> GetOrPickAndRememberFolderAsync(string key)
        {
            if (StorageApplicationPermissions.FutureAccessList.ContainsItem(key))
            {
                return await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(key);
            }
            var picker = new FolderPicker();
            picker.FileTypeFilter.Add("*");
            StorageFolder folder = await picker.PickSingleFolderAsync();
            if (folder != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace(key, folder);
            }
            return folder;
        }
    }
}

