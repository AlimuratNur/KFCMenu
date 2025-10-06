using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFCMenu.ViewModel.Base;
using KFCMenu.Models;

namespace KFCMenu.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        #region SelectedDish
        private FoodType _SelectedFoodType;
        public FoodType SelectedFoodType { 
            get =>  _SelectedFoodType;  
            set => Set(ref _SelectedFoodType, value);  }
        #endregion

    }
}
