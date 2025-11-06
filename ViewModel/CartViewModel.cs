using KFCMenu.Infrastructure.Commands;
using KFCMenu.Services;
using KFCMenu.Stores;
using KFCMenu.ViewModel.Base;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KFCMenu.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        public DishCart Dishes { get;  }

        public ICommand OnMenuPage { get; }

        public CartViewModel(NavigationStore navigationStore)
        {
            OnMenuPage = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore));

            Dishes = new();

        }
    }
}
