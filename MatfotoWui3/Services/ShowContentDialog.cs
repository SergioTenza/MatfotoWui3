using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Services
{
    public class ShowContentDialog
    {
        public async void ShowDialog(object sender, RoutedEventArgs e)
        {
            ContentDialog subscribeDialog = new ContentDialog
            {
                Title = "Subscribe to App Service?",
                Content = "Listen, watch, and play in high definition for only $9.99/month. Free to try, cancel anytime.",
                CloseButtonText = "Not Now",
                PrimaryButtonText = "Subscribe",
                SecondaryButtonText = "Try it",
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
    }
}
