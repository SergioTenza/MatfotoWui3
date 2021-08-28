
using CommunityToolkit.Mvvm.DependencyInjection;
using MatfotoWui3.ViewModels;
using Microsoft.UI.Xaml.Controls;


namespace MatfotoWui3.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            ViewModel = Ioc.Default.GetService<MainViewModel>();
            InitializeComponent();
        }

        private void LoadingControl_Loading(Microsoft.UI.Xaml.FrameworkElement sender, object args)
        {

        }
    }
}
