namespace MAUI.App.ViewModels;

public partial class VideoViewModel : BaseViewModel
{
	[ObservableProperty]
	public string source = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
}
