using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFCMenu.ViewModel.Base;
using KFCMenu.Models;
using KFCMenu.Services;
using System.Windows.Data;
using System.IO;
using System.Windows.Input;
using KFCMenu.Infrastructure.Commands;



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

        private FoodType _Burgers;
        public FoodType Burgers { get => _Burgers; set => Set(ref _Burgers, value); }


        private FoodType _Chickens;
        public FoodType  Chickens{ get => _Chickens; set => Set(ref _Chickens, value); }


        private FoodType _Drinks;
        public FoodType Drinks { get => _Drinks; set => Set(ref _Drinks, value); }


        #endregion

        #region Commands
        public ICommand ChangePage { get; }

        private bool CanChangePageExecuted(object p) => p is FoodType;
        private void OnChangePageExecute(object p)
        {
            if (!(p is FoodType)) return;
            SelectedFoodType = (FoodType)p;
        }

        #endregion

        public MainViewModel()
        {
            #region InitCommands
            ChangePage = new LambdaCommand(OnChangePageExecute,CanChangePageExecuted);
            #endregion

            _Initialize();
        }

        private async void _Initialize()
        {
            var jsonReader = new JsonDataService<Dish>();
            
            #region combosInit
            var comboList = await Load(jsonReader, GetPath("data.json"));
            Combos = new FoodType() {Title = "Combos", Diches = comboList};
            SelectedFoodType = Combos;
            #endregion

            #region BurgerInit
            Burgers = new FoodType() {Title = "Burgers", Diches = await Load(jsonReader, GetPath("Burgers.json"))};
            #endregion

            #region ChickensInit
            Chickens = new FoodType() { Title = "Chickens", Diches = await Load(jsonReader, GetPath("Chickens.json"))};
            #endregion

            #region DrinksInit
            Drinks = new FoodType() { Title = "Drinks", Diches = await Load(jsonReader, GetPath("Drinks.json")) };
            #endregion
        }

        private string GetPath(string fileName) 
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data/" + fileName);

        private  async Task<List<Dish>> Load(JsonDataService<Dish> jsonReader, string filePath) 
            => await jsonReader.LoadAsync(filePath);
        
    }
} 
