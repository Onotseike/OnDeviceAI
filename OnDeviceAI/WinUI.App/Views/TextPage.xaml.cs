using Microsoft.UI.Xaml.Controls;

using WinUI.App.ViewModels;

namespace WinUI.App.Views;

public sealed partial class TextPage : Page
{
    public TextViewModel ViewModel
    {
        get;
    }

    public TextPage()
    {
        ViewModel = App.GetService<TextViewModel>();
        InitializeComponent();
    }
}
