using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFCMenu.ViewModel.Base;
using KFCMenu.Models;
using System.Windows.Data;

namespace KFCMenu.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Title
        private string _Title = "KFC Menu Window";
        public string Title { 
            get => _Title; 
            set => Set(ref _Title, value); } 
        #endregion


        #region FoodTypes
        public ICollection<FoodType> FoodTypes { get;  }
        
        #endregion

        #region SelectedDish
        private FoodType? _SelectedFoodType;
        public FoodType SelectedFoodType { 
            get =>  _SelectedFoodType;  
            set => Set(ref _SelectedFoodType, value);  }
        #endregion

        public MainViewModel()
        {
            
            FoodTypes = new List<FoodType>();
            var dishes = new List<Dish>();
            dishes.Add(new Dish("MegaCombo", "Cool combo with a lot of chicken and french fries", 10000d));
            var combo = new FoodType() { Title = "Combo" ,
                Diches = dishes.ToArray()
            };
            
            FoodTypes.Add(combo);
        }
    }
} 
