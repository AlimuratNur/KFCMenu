using KFCMenu.Infrastructure.Commands.Base;
using KFCMenu.Stores;
using KFCMenu.ViewModel.Base;

namespace KFCMenu.Infrastructure.Commands;

class NavigationCommand<TViewModel> : Command 
    where TViewModel: ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _changeViewModel;
    

    public NavigationCommand(NavigationStore navigationStore, Func<TViewModel> changeViewModel)
    {
        _navigationStore = navigationStore;
        _changeViewModel = changeViewModel;
    }

    public override bool CanExecute(object parameter) => true;
    
    public override void Execute(object parameter)
    {
        _navigationStore.CurrentViewModel = _changeViewModel();
    }
}

