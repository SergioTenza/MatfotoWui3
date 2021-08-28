using MatfotoWui3.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MatfotoWui3.Services
{
    public class PickFolderService : IPickFolderService
    {
        public async Task<IStorageItem> GetSelectedFolderAsync()
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();

            // Pass in the current WinUI window and get its handle
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("key", folder);
                return folder;
            }
            else
            {
                return null; 
            }
        }
    }
}
