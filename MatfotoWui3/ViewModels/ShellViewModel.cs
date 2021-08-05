using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Core.Contracts.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

namespace MatfotoWui3.ViewModels
{
    // You can show pages in different ways (update main view, navigate or right pane)
    // using the NavigationService and RightPaneService.
    // Read more about MenuBar project type here:
    // https://github.com/Microsoft/WindowsTemplateStudio/blob/release/docs/WinUI/projectTypes/menubar.md
    public class ShellViewModel : ObservableRecipient
    {
        private bool _isBackEnabled;
        private object _selected;
        private ICommand _menuFileSettingsCommand;        
        private ICommand _menuViewsCarnetCommand;
        private ICommand _menuViewsCopiasCommand;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuFileExitCommand;

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ICommand MenuFileSettingsCommand => _menuFileSettingsCommand ?? (_menuFileSettingsCommand = new RelayCommand(OnMenuFileSettings));

        public ICommand MenuViewsCarnetCommand => _menuViewsCarnetCommand ?? (_menuViewsCarnetCommand = new RelayCommand(OnMenuViewsCarnet));

        public ICommand MenuViewsCopiasCommand => _menuViewsCopiasCommand ?? (_menuViewsCopiasCommand = new RelayCommand(OnMenuViewsCopias));

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        public INavigationService NavigationService { get; }

        public IRightPaneService RightPaneService { get; }       

        public bool IsBackEnabled
        {
            get { return _isBackEnabled; }
            set { SetProperty(ref _isBackEnabled, value); }
        }

        public object Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ShellViewModel(INavigationService navigationService, IRightPaneService rightPaneService)
        {
            NavigationService = navigationService;
            NavigationService.Navigated += OnNavigated;
            RightPaneService = rightPaneService;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            IsBackEnabled = NavigationService.CanGoBack;
        }

        private void OnMenuFileExit() => Application.Current.Exit();

        private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName, null, true);

        private void OnMenuViewsCopias() => NavigationService.NavigateTo(typeof(CopiasViewModel).FullName, null, true);

        private void OnMenuViewsCarnet() => NavigationService.NavigateTo(typeof(CarnetViewModel).FullName, null, true);

        private void OnMenuFileSettings() => RightPaneService.OpenInRightPane(typeof(SettingsViewModel).FullName);
    }
}
