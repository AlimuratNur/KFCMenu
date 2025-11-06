using KFCMenu.ViewModel.Base;

namespace KFCMenu.Stores;

public class NavigationStore
{
    //We will call this event(signal) if current page changes
    public event Action CurrentViewModelChanged;

    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel 
    { 
        get => _currentViewModel;
        set 
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}

