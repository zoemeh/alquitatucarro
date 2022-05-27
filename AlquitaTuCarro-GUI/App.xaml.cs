using AlquitaTuCarro_GUI.Activation;
using AlquitaTuCarro_GUI.Contracts.Services;
using AlquitaTuCarro_GUI.Core.Contracts.Services;
using AlquitaTuCarro_GUI.Core.Services;
using AlquitaTuCarro_GUI.Helpers;
using AlquitaTuCarro_GUI.Models;
using AlquitaTuCarro_GUI.Services;
using AlquitaTuCarro_GUI.ViewModels;
using AlquitaTuCarro_GUI.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace AlquitaTuCarro_GUI
{
    public partial class App : Application
    {
        // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Default Activation Handler
                services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

                // Other Activation Handlers

                // Services
                services.AddSingleton<ILocalSettingsService, LocalSettingsServicePackaged>();
                services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                services.AddTransient<INavigationViewService, NavigationViewService>();

                services.AddSingleton<IActivationService, ActivationService>();
                services.AddSingleton<IPageService, PageService>();
                services.AddSingleton<INavigationService, NavigationService>();

                // Core Services
                services.AddSingleton<ISampleDataService, SampleDataService>();
                services.AddSingleton<IFileService, FileService>();

                // Views and ViewModels
                services.AddTransient<SettingsViewModel>();
                services.AddTransient<SettingsPage>();
                services.AddTransient<ListDetailsViewModel>();
                services.AddTransient<ListDetailsPage>();
                services.AddTransient<ContentGridDetailViewModel>();
                services.AddTransient<ContentGridDetailPage>();
                services.AddTransient<ContentGridViewModel>();
                services.AddTransient<ContentGridPage>();
                services.AddTransient<FuelTypesGridViewModel>();
                services.AddTransient<FuelTypesGridPage>();
                services.AddTransient<MainViewModel>();
                services.AddTransient<MainPage>();
                services.AddTransient<ShellPage>();
                services.AddTransient<ShellViewModel>();

                // Configuration
                services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
            })
            .Build();

        public static T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO: Log and handle exceptions as appropriate.
            // For more details, see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs.
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = App.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }
    }
}
