using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Services
{
    public class StorageService : IStorageService
    {
        private List<Folder> _folders;
        private List<string> _files;

        public StorageService()
        {
            if (_folders != null)
            {
                return;
            }
            else
            {
                _folders = new();
            }

            if (_files != null)
            {
                return;
            }
            else
            {
                _files = new();
            }
            
            
        }
        
        public List<Folder> Folders
        {
            get => _folders;
            set => GetAllFolders();
        }

        public List<string> Files
        {
            get => _files;
            set => GetAllFiles();
        }

        public bool AddFile(string fileName, string folderName)
        {
            if (Folders == null) return false;
            foreach (var folder in Folders)
            {
                if (folder.FolderPath == folderName)
                {
                    folder.FolderFiles.Add(fileName);
                    return true;
                }
            }
            return false;            
        }

        public bool AddFolder(string folderName)
        {
            try
            {
                Folder folderToAdd = new();
                folderToAdd.FolderPath = folderName;
                var folderFiles = System.IO.Directory.GetFiles(folderName, "*.png,*.jpg,*.jpeg,*.bmp");
                foreach (var file in folderFiles)
                {
                    folderToAdd.FolderFiles.Add(file);
                }
                _folders.Append(folderToAdd);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private List<string> GetAllFiles()
        {
            if (_files == null)
            {
                _files = new();
            }

            foreach (var folder in Folders)
            {
                foreach (var file in folder.FolderFiles)
                {
                    _files.Add(file);
                }
            }
            return _files;
        }

        private List<Folder> GetAllFolders()
        {
            if (_folders == null)
            {
                _folders = new();
            }
            return _folders;
        }

        public bool RemoveFile(string fileName)
        {
            foreach (var file in Files)
            {
                if (file == fileName)
                {
                    Files.Remove(file);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveFolder(string folderName)
        {
            foreach (var folder in Folders)
            {
                if (folder.FolderPath == folderName)
                {
                    Folders.Remove(folder);
                    return true;
                }
            }
            return false;
        }
    }
}
