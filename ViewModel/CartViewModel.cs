using System.Linq;
using System.Threading.Tasks;
using KFCMenu.Services;
using KFCMenu.ViewModel.Base;

namespace KFCMenu.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        public DishCart Dishes { get;  }
        public CartViewModel()
        {
            Dishes = new();

        }
    }
}
