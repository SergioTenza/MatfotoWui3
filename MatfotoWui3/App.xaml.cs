using CommunityToolkit.Mvvm.DependencyInjection;

using MatfotoWui3.Activation;
using MatfotoWui3.Contracts.Services;
using MatfotoWui3.Core.Contracts.Services;
using MatfotoWui3.Core.Models;
using MatfotoWui3.Core.Services;
using MatfotoWui3.Helpers;
using MatfotoWui3.Services;
using MatfotoWui3.ViewModels;
using MatfotoWui3.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace MatfotoWui3
{
    public partial class App : Application
    {
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public static Printer printer { get; set; } = new Printer();

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }

        private System.IServiceProvider ConfigureServices()
        {
            // TODO WTS: Register your services, viewmodels and pages here
            var services = new ServiceCollection();

            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<IRightPaneService, RightPaneService>();
            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IPickFileService, PickFileService>();
            services.AddSingleton<IPickFolderService, PickFolderService>();
            services.AddSingleton<MatfotoWui3.Contracts.Services.IPrinterService, MatfotoWui3.Services.PrinterService>();
            
            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IPrinterStatusService, PrinterStatusService>();

            // Views and ViewModels
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<CopiasViewModel>();
            services.AddTransient<CopiasPage>();
            services.AddTransient<CarnetViewModel>();
            services.AddTransient<CarnetPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            return services.BuildServiceProvider();
        }
    }
}
