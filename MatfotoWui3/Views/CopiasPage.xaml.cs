using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using MatfotoWui3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace MatfotoWui3.Views
{
    public sealed partial class CopiasPage : Page
    {
        public CopiasViewModel ViewModel { get; }

        public CopiasPage()
        {
            ViewModel = Ioc.Default.GetService<CopiasViewModel>();
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
