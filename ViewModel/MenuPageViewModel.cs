using KFCMenu.Infrastructure.Commands;
using KFCMenu.Models;
using KFCMenu.Services;
using KFCMenu.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KFCMenu.ViewModel
{
    public class MenuPageViewModel : ViewModelBase
    {   
        public ICollection<FoodType> FoodTypes;



        #region -------------------------------------------SelectedFoodType-------------------------------------------
        private FoodType _SelectedFoodType;

        public FoodType SelectedFoodType
        {
            get => _SelectedFoodType;
            set => Set(ref _SelectedFoodType, value);
        }
        #endregion

        #region -------------------------------------------Food In Cart Count-------------------------------------------
        private int _FoodInCartCount = 0;
        public int FoodInCartCount { get => _FoodInCartCount; set => Set(ref _FoodInCartCount, value); }
        #endregion

        #region -------------------------------------------Commands-------------------------------------------
        public ICommand ChangePage { get; }

        private bool CanChangePageExecuted(object p) => p is FoodType;
        private void OnChangePageExecute(object p)
        {
            SelectedFoodType = (FoodType)p;
        }


        public ICommand AddDishToCart { get; }

        private bool CanAddDishToCartExecuted(object p) => true;
        private void OnAddDishToCartExecute(object p) => FoodInCartCount = FoodInCartCount + 1;
        #endregion


        public MenuPageViewModel()
        {
            #region InitCommands
            ChangePage = new LambdaCommand(OnChangePageExecute, CanChangePageExecuted);
            AddDishToCart = new LambdaCommand(OnAddDishToCartExecute, CanAddDishToCartExecuted);
            #endregion
            FoodTypes = new List<FoodType>(4);
            _Initialize();
        }


        private async void _Initialize()
        {
            var jsonReader = new JsonDataService<Dish>();

            #region combosInit
            var comboList = await Load(jsonReader, GetPath("data.json"));
            FoodTypes.Add( new FoodType() { Title = "Combos", Diches = comboList });
            SelectedFoodType = FoodTypes.Last();
            #endregion

            #region BurgerInit
            FoodTypes.Add(new FoodType() 
            { Title = "Burgers", 
                Diches = await Load(jsonReader, GetPath("Burgers.json"))});
            #endregion

            #region ChickensInit
            FoodTypes.Add(new FoodType() 
            { Title = "Chickens", 
                Diches = await Load(jsonReader, GetPath("Chickens.json"))});
            #endregion

            #region DrinksInit
            FoodTypes.Add(new FoodType() 
            { Title = "Drinks", 
                Diches = await Load(jsonReader, GetPath("Drinks.json"))});
            #endregion

        }


        #region --------------------------------Help methods for initialize--------------------------------
        private string GetPath(string fileName)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/" + fileName);

        private async Task<List<Dish>> Load(JsonDataService<Dish> jsonReader, string filePath)
            => await jsonReader.LoadAsync(filePath);
        #endregion
    }
}
