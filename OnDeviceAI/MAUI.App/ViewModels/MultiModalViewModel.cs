using CommunityToolkit.Maui.Core;

namespace MAUI.App.ViewModels;

public partial class MultiModalViewModel : BaseViewModel
{
	[ObservableProperty]
	public ObservableCollection<IDrawingLine> lines = new();

	[RelayCommand]
	public void Clear()
	{
		Lines.Clear();
	}
}
