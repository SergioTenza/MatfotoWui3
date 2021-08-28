using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Contracts.ViewModels;
using MatfotoWui3.Core.Contracts.Services;
using MatfotoWui3.Core.Models;
using MatfotoWui3.Helpers;
using MatfotoWui3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using Windows.UI.Popups;

namespace MatfotoWui3.ViewModels
{
    public class MainViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IPickFileService _pickFileService;
        private readonly IPickFolderService _pickFolderService;

        private ICommand _commandBar_CleanSelection;
        public ICommand CommandBar_CleanSelection => _commandBar_CleanSelection ?? (_commandBar_CleanSelection = new RelayCommand(CleanSelections));

        public MainViewModel(IPickFileService pickFileService, IPickFolderService pickFolderService)
        {
            _pickFileService = pickFileService;
            _pickFolderService = pickFolderService;
        }



        private bool FolderFutureAccess { get => StorageFolderHelpers.FutureAccessListEmpty(); }

        public ObservableCollection<Models.FolderListMember> folderList { get; private set; } = new ObservableCollection<Models.FolderListMember>();

        public ObservableCollection<Models.Folder> Folders { get; private set; } = new ObservableCollection<MatfotoWui3.Models.Folder>();

        public ObservableCollection<IStorageItem> FoldersTest { get; private set; } = new ObservableCollection<IStorageItem>();

        public ObservableCollection<StorageFile> FolderContent { get; private set; } = new ObservableCollection<StorageFile>();

        public ObservableString ItemsSeleccionados = new() { Message = $"Items seleccionados: 0" };

        public ObservableBool IsBusy = new() { State = false };

        private int SelectedItems;


        public async Task ShowLoadingDialogAsync()
        {
            IsBusy.State = true;
            await Task.Delay(5000);
            IsBusy.State = false;
        }

        private void CleanSelections()
        {
            Folders.Clear();
            FoldersTest.Clear();
            FolderContent.Clear();
        }

        private void AddSelectedItem()
        {
            SelectedItems++;
            ItemsSeleccionados.Message = $"Items seleccionados: {SelectedItems}";
        }

        private void RemoveSelectedItem()
        {
            SelectedItems--;
            ItemsSeleccionados.Message = $"Items seleccionados: {SelectedItems}";
        }
        private async void UpdateFoldersListView(StorageFolder folder)
        {
            // Set query options with filter and sort order for results
            List<string> fileTypeFilter = new List<string>();
            fileTypeFilter.Add(".jpg");
            fileTypeFilter.Add(".jpeg");
            fileTypeFilter.Add(".png");
            fileTypeFilter.Add(".bmp");
            fileTypeFilter.Add(".gif");
            var queryOptions = new QueryOptions(CommonFileQuery.OrderByName, fileTypeFilter);

            // Create query and retrieve files.
            //var query = KnownFolders.PicturesLibrary.CreateFileQueryWithOptions(queryOptions);            
            var query = folder.CreateFileQueryWithOptions(queryOptions);

            IReadOnlyList<StorageFile> fileList = await query.GetFilesAsync();

            //Process results
            FolderContent.Clear();

            foreach (StorageFile file in fileList)
            {
                FolderContent.Add(file);
            }
            // Process results
            //foreach (StorageFile file in fileList)
            //{
            //    // Get thumbnail
            //    const uint requestedSize = 190;
            //    const ThumbnailMode thumbnailMode = ThumbnailMode.PicturesView;
            //    const ThumbnailOptions thumbnailOptions = ThumbnailOptions.UseCurrentScale;
            //    var thumbnail = await file.GetThumbnailAsync(thumbnailMode, requestedSize, thumbnailOptions);                
            //}            
        }
        private async void GetFoldersFromFutureAccessList()
        {
            if (FolderFutureAccess)
            {
                var folders = StorageApplicationPermissions.FutureAccessList;
                foreach (AccessListEntry entry in folders.Entries)
                {
                    string mruToken = entry.Token;
                    string mruMetadata = entry.Metadata;
                    IStorageItem item = await folders.GetItemAsync(mruToken);
                    // The type of item will tell you whether it's a file or a folder.
                    if (item.IsOfType(StorageItemTypes.Folder))
                    {
                        var itemFolder = (StorageFolder)item;
                        UpdateFoldersListView(itemFolder);
                    }
                }
            }
        }

        public async void OpenFileDialog()
        {
            var response = await _pickFileService.GetSelectedFileAsync();
            if (!String.IsNullOrEmpty(response))
            {
                CreateFolderSingleFile(response);
            }
        }

        public async void OpenFolderDialog()
        {   
            var response = await _pickFolderService.GetSelectedFolderAsync();

            if (response != null)
            {
                CreateFolder(response);
            }            
        }

        private void CreateFolder(IStorageItem item)
        {
            var key = DateTime.Now.ToString();
            var newCustomFolder = new Models.Folder(item, key);
            Folders.Add(newCustomFolder);
            FoldersTest.Add(item);

            if (item.IsOfType(StorageItemTypes.Folder))
            {
                var itemFolder = (StorageFolder)item;
                if (itemFolder != null)
                {
                    StorageApplicationPermissions.FutureAccessList.AddOrReplace(key, itemFolder);
                }
                UpdateFoldersListView(itemFolder);
                AddSelectedItem();
            }
        }

        public async void SelectedFolder(object sender, ItemClickEventArgs e)
        {
            
            if(e != null)
            {
                var folder = e.ClickedItem as MatfotoWui3.Models.Folder;
                // Do Stuff Here
                if (folder != null)
                {
                    foreach (var item in Folders)
                    {
                        if (item.FaToken == folder.FaToken)
                        {
                            if (StorageApplicationPermissions.FutureAccessList.ContainsItem(folder.FaToken))
                            {
                                var existingFolder =  await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(folder.FaToken);
                                if (existingFolder != null)
                                {
                                    UpdateFoldersListView(existingFolder);                                    
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
        }

        public void DeleteItem(object sender, RightTappedRoutedEventArgs e)
        {
            //GridView grid = (GridView)sender;
            var folder = (e.OriginalSource as FrameworkElement)?.DataContext as MatfotoWui3.Models.Folder;

            foreach (var item in Folders)
            {
                if (item.FaToken == folder.FaToken)
                {
                    Folders.Remove(folder);
                    break;
                }
            }
            if (FolderContent.Count > 0)
            {
                FolderContent.Clear();
            }
            RemoveSelectedItem();
        }

        private void CreateFolderSingleFile(string folderName)
        {
            //ContentDialog subscribeDialog = new ContentDialog
            //{
            //    Title = "Informacion del Objeto",
            //    Content = $"{folder.FolderName} \n {folder.FaToken}",
            //    CloseButtonText = "Cerrar",
            //    PrimaryButtonText = "Ok",
            //    DefaultButton = ContentDialogButton.Primary
            //};

            //if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
            //{
            //    subscribeDialog.XamlRoot = (grid).XamlRoot;
            //}

            //try
            //{
            //    ContentDialogResult result = await subscribeDialog.ShowAsync();
            //}
            //catch (Exception)
            //{
            //    // The dialog didn't open, probably because another dialog is already open.
            //}
        }

        public void OnNavigatedTo(object parameter)
        {

        }

        public void OnNavigatedFrom()
        {

        }
    }
}
