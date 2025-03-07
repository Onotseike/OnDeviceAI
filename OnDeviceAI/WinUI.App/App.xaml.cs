﻿using Common.Contracts.Services;
using Common.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

using WinUI.App.Activation;
using WinUI.App.Contracts.Services;
using WinUI.App.Models;
using WinUI.App.Services;
using WinUI.App.ViewModels;
using WinUI.App.Views;

namespace WinUI.App;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar { get; set; }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            _ = services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            _ = services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            _ = services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            _ = services.AddTransient<IWebViewService, WebViewService>();
            _ = services.AddTransient<INavigationViewService, NavigationViewService>();

            _ = services.AddSingleton<IActivationService, ActivationService>();
            _ = services.AddSingleton<IPageService, PageService>();
            _ = services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            _ = services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            _ = services.AddTransient<SettingsViewModel>();
            _ = services.AddTransient<SettingsPage>();
            _ = services.AddTransient<MultiModalViewModel>();
            _ = services.AddTransient<MultiModalPage>();
            _ = services.AddTransient<VideoViewModel>();
            _ = services.AddTransient<VideoPage>();
            _ = services.AddTransient<ImageViewModel>();
            _ = services.AddTransient<ImagePage>();
            _ = services.AddTransient<AudioViewModel>();
            _ = services.AddTransient<AudioPage>();
            _ = services.AddTransient<TextViewModel>();
            _ = services.AddTransient<TextPage>();
            _ = services.AddTransient<ShellPage>();
            _ = services.AddTransient<ShellViewModel>();

            // Configuration
            _ = services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
