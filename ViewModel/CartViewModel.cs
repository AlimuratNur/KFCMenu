using KFCMenu.Infrastructure.Commands;
using KFCMenu.Models;
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
        #region ---------------------------------------------------Command---------------------------------------------------
        public ICommand OnMenuPage { get; }

        public ICommand OnRemoveItem { get; }
        private bool CanRemoveItemExecuted(object p)
        {
            if (p is null || !(p is CartItem))
            {
                return false;
            }
            var d = (CartItem)p;
            return Dishes.Contains(d);
        }
        private void OnRemoveItemExecute(object p) 
        {
            var d = (CartItem)p;
            Dishes.RemoveWithCount(d, 1);
        }

        #endregion


        public CartViewModel(NavigationStore navigationStore, DishCart? cartItems)
        {
            #region Commands
            OnMenuPage = new NavigationCommand<MenuPageViewModel>(navigationStore, () => new MenuPageViewModel(navigationStore, Dishes));
            OnRemoveItem = new LambdaCommand(OnRemoveItemExecute, CanRemoveItemExecuted); 
            #endregion
            Dishes = cartItems ?? new DishCart();

        }
    }
}
