using Microsoft.UI.Xaml;

using WinUI.App.Contracts.Services;
using WinUI.App.ViewModels;

namespace WinUI.App.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame?.Content == null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _ = _navigationService.NavigateTo(typeof(TextViewModel).FullName!, args.Arguments);

        await Task.CompletedTask;
    }
}
