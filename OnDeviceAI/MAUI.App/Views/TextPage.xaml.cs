namespace MAUI.App.Views;

public partial class TextPage : ContentPage
{
	public TextPage(TextViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
