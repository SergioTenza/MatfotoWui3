using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;

namespace MatfotoWui3.Helpers
{
    public static class StorageFolderFilesHelpers
    {
        public static async Task<bool> FileExistsInFolderAsync(StorageFolder folder, string filename)
        {
            var item = await folder.TryGetItemAsync(filename);
            return (item != null) && item.IsOfType(StorageItemTypes.File);
        }

        public static async Task<bool> FileExistsInSubtreeAsync(StorageFolder rootFolder, string filename)
        {
            if (filename.IndexOf('"') >= 0) throw new ArgumentException("filename");
            var options = new QueryOptions
            {
                FolderDepth = FolderDepth.Deep,
                UserSearchFilter = $"filename:=\"{filename}\"" // “:=” is the exact-match operator
            };
            var files = await rootFolder.CreateFileQueryWithOptions(options).GetFilesAsync();
            return files.Count > 0;
        }

        public static async Task<bool> FileExistsAsync(StorageFolder folder, string filename,
            bool isRecursive = false) => isRecursive
                ? await FileExistsInSubtreeAsync(folder, filename)
                : await FileExistsInFolderAsync(folder, filename);
    }
}

        