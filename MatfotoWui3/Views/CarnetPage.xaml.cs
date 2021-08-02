using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using MatfotoWui3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace MatfotoWui3.Views
{
    public sealed partial class CarnetPage : Page
    {
        public CarnetViewModel ViewModel { get; }

        public CarnetPage()
        {
            ViewModel = Ioc.Default.GetService<CarnetViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {
            if (e == ListDetailsViewState.Both)
            {
                ViewModel.EnsureItemSelected();
            }
        }
    }
}
