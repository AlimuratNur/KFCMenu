using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFCMenu.ViewModel.Base;
using KFCMenu.Models;
using System.Windows.Data;
using KFCMenu.Services;
using System.IO;

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


        #region SelectedFoodType
        private FoodType _SelectedFoodType;
        public FoodType SelectedFoodType { 
            get =>  _SelectedFoodType;  
            set => Set(ref _SelectedFoodType, value);  }
        #endregion


        #region SelectedPages

        private FoodType _Combos;
        public FoodType Combos { get => _Combos;
            set => Set(ref _Combos, value);
        }



        #endregion

        public MainViewModel()
        {

            _Initialize();
        }

        private async void _Initialize()
        {
            var jsonReader = new JsonDataService<Dish>();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/data.json");//"C:\\Users\\FPS SHOP\\Desktop\\PL\\Cs\\KFCMenu\\Data\\data.json"
            #region combosInit
            var comboList = await Load(jsonReader, filePath);
            _Combos = new FoodType() {Title = "Combos", Diches = comboList.ToArray()};
            SelectedFoodType = _Combos;
            #endregion 
            
            
        }

        private  async Task<List<Dish>> Load(JsonDataService<Dish> jsonReader, string filePath) 
            => await jsonReader.LoadAsync(filePath);
        
    }
} 
