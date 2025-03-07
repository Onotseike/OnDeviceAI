using Microsoft.UI.Xaml.Controls;

using WinUI.App.ViewModels;

namespace WinUI.App.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class AudioPage : Page
{
    public AudioViewModel ViewModel
    {
        get;
    }

    public AudioPage()
    {
        ViewModel = App.GetService<AudioViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
