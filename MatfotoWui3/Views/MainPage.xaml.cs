
using CommunityToolkit.Mvvm.DependencyInjection;

using MatfotoWui3.ViewModels;

using Microsoft.UI.Xaml.Controls;

using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using WinRT;


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
    }
}
