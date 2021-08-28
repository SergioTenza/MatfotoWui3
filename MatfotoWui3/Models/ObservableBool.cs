using CommunityToolkit.Mvvm.ComponentModel;

namespace MatfotoWui3.Models
{
    public class ObservableBool : ObservableObject
    {
        private bool state;

        public bool State
        {
            get => state;
            set => SetProperty(ref state, value);
        }
    }
}
