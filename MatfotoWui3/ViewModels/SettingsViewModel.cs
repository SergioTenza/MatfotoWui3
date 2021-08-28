using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CitizenPrinter;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Core.Contracts.Services;
using MatfotoWui3.Core.Models;
using MatfotoWui3.Helpers;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel;

namespace MatfotoWui3.ViewModels
{
    public class SettingsViewModel : ObservableRecipient
    {
        private bool _loadingPrinters;

        public bool LoadingPrinters
        {
            get { return _loadingPrinters; }
            set { _loadingPrinters = value; }
        }

        private readonly IThemeSelectorService _themeSelectorService;
        private readonly IPrinterStatusService _printerStatusService;


        public ObservableCollection<string> Printers { get; private set; } = new ObservableCollection<string>();
        

        private PrinterStatus _printerStatus;

        public PrinterStatus PrinterStatus
        {
            get { return _printerStatus; }
            set { SetProperty(ref _printerStatus, value); }
        }

        private ElementTheme _elementTheme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { SetProperty(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { SetProperty(ref _versionDescription, value); }
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            if (ElementTheme != param)
                            {
                                ElementTheme = param;
                                await _themeSelectorService.SetThemeAsync(param);
                            }
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel(IThemeSelectorService themeSelectorService, IPrinterStatusService printerStatusService)
        {
            _themeSelectorService = themeSelectorService;
            _elementTheme = _themeSelectorService.Theme;
            VersionDescription = GetVersionDescription();
            LoadingPrinters = true;
            var items = PopulatePrinters();
            foreach (var printer in items)
            {
                Printers.Add(printer);
            }
            LoadingPrinters = false;
            _printerStatusService = printerStatusService;
            
        }

        private IList<string> PopulatePrinters()
        {
            var printerHelper = new GetInstalledPrinters();
            return printerHelper.FilteredPrinters;
            
        }
        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public async void ShowDialog(object sender, RoutedEventArgs e)
        {
            string content = $"PRINTER NAME: {App.printer.PrinterName}\nPRINTER FIRMWARE: {App.printer.Firmware}\nPRINTER PORT NAME: {App.printer.PortName}\nPRINTER PORT NUMBER: {App.printer.PortNumber}\n";
            ContentDialog subscribeDialog = new ContentDialog
            {
                Title = "Printer Info",
                Content = content,
                CloseButtonText = "Close",
                PrimaryButtonText = "Ok",                
                DefaultButton = ContentDialogButton.Primary
            };

            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
            {
                subscribeDialog.XamlRoot = ((AppBarButton)sender).XamlRoot;
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

        public void ComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the instance of ComboBox
            ComboBox comboBox = sender as ComboBox;
            // Get the ComboBox selected item text
            string selectedItems = comboBox.SelectedItem.ToString();

            PrinterStatus = _printerStatusService.GetPrinterStatus(selectedItems);
            App.printer.PrinterName = _printerStatus.PrinterName;
            App.printer.PortName = _printerStatus.PrinterPortName;            
            App.printer.PortNumber = _printerStatus.PrinterPortNumber;
            App.printer.Firmware = _printerStatus.PrinterFirmware;
        }

    }
}
