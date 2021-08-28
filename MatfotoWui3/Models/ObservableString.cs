using CommunityToolkit.Mvvm.ComponentModel;

namespace MatfotoWui3.Models
{
    public class ObservableString : ObservableObject
    {
        private string message;

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
    }
}
