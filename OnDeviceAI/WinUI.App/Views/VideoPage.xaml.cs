using Microsoft.UI.Xaml.Controls;

using WinUI.App.ViewModels;

namespace WinUI.App.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class VideoPage : Page
{
    public VideoViewModel ViewModel
    {
        get;
    }

    public VideoPage()
    {
        ViewModel = App.GetService<VideoViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
