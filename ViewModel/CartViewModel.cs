using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFCMenu.Models;
using KFCMenu.ViewModel.Base;

namespace KFCMenu.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        public ICollection<Dish> Dishes { get;  }
        public CartViewModel()
        {
            Dishes = new List<Dish>();
        }
    }
}
