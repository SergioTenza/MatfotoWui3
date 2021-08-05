using MatfotoWui3.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Services
{
    public class PickFileService : IPickFileService
    {
        public async Task<string> GetSelectedFileAsync()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();

            // Pass in the current WinUI window and get its handle
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                //Console.WriteLine(file.Name); 
                // Store file for future access                
                //Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
                return file.Path;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
