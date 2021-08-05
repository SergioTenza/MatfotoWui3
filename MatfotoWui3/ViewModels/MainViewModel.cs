using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Contracts.ViewModels;
using MatfotoWui3.Core.Contracts.Services;
using MatfotoWui3.Core.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.UI.Popups;

namespace MatfotoWui3.ViewModels
{
    public class MainViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IDataService _dataService;
        private readonly IPickFileService _pickFileService;
        private readonly IPickFolderService _pickFolderService;        

        private ICommand _commandBar_CleanSelection;
        public ICommand CommandBar_CleanSelection => _commandBar_CleanSelection ?? (_commandBar_CleanSelection = new RelayCommand(CleanSelections));        
        
        public MainViewModel(IDataService dataService, IPickFileService pickFileService, IPickFolderService pickFolderService)
        {
            _dataService = dataService;
            _pickFileService = pickFileService;
            _pickFolderService = pickFolderService;
        }

        public ObservableCollection<Folder> Folders { get; private set; } = new ObservableCollection<Folder>();

        private void CleanSelections()
        {
            Folders.Clear();
        }

        private ObservableCollection<CustomFolderObject> GetFoldersFromRepository()
        {
            var response = new ObservableCollection<CustomFolderObject>();
            var repository = _dataService.GetFolders();

            foreach (var folder in repository)
            {
                var newCustomDataObject = new CustomFolderObject();
                newCustomDataObject.ImageLocation = "/Images/folder.png";
                newCustomDataObject.Title = folder.FolderName;
                response.Add(newCustomDataObject);
            }
            return response;
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
            if (!String.IsNullOrEmpty(response))
            {
                CreateFolder(response);
            }
        }

        private void CreateFolder(string folderName)
        {
            var newCustomFolder = new Folder();
            newCustomFolder.FolderName = $"{folderName}";
            newCustomFolder.ImageLocation = "/Images/folder.png";
            Folders.Add(newCustomFolder);
        }

        public async void DeleteItem(object sender, object args)
        {
            Folder item = new Folder() { FolderName = "Ha sido NULL" };

            GridView grid = (GridView)sender;
            //if (grid != null)
            //{
            //    item.FolderName = grid.Content.ToString();
            //}
            if (grid.SelectedIndex != -1)
            {
                item = Folders[grid.SelectedIndex];

            }
            ContentDialog subscribeDialog = new ContentDialog
            {
                Title = "Informacion del Objeto",
                Content = item.FolderName,
                CloseButtonText = "Not Now",
                PrimaryButtonText = "Subscribe",
                DefaultButton = ContentDialogButton.Primary
            };

            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
            {
                subscribeDialog.XamlRoot = (grid).XamlRoot;
            }

            try
            {
                ContentDialogResult result = await subscribeDialog.ShowAsync();
            }
            catch (Exception)
            {
                // The dialog didn't open, probably because another dialog is already open.
            }



        }

        private void CreateFolderSingleFile(string folderName)
        {
            
        }

        public void OnNavigatedTo(object parameter)
        {
            
        }

        public void OnNavigatedFrom()
        {
            
        }
    }
}
