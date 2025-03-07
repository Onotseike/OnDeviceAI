using Microsoft.UI.Xaml.Controls;

using WinUI.App.ViewModels;

namespace WinUI.App.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class MultiModalPage : Page
{
    public MultiModalViewModel ViewModel
    {
        get;
    }

    public MultiModalPage()
    {
        ViewModel = App.GetService<MultiModalViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
