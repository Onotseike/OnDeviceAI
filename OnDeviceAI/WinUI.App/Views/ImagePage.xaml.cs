using Microsoft.UI.Xaml.Controls;

using WinUI.App.ViewModels;

namespace WinUI.App.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class ImagePage : Page
{
    public ImageViewModel ViewModel
    {
        get;
    }

    public ImagePage()
    {
        ViewModel = App.GetService<ImageViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
