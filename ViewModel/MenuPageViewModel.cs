using KFCMenu.Infrastructure.Commands;
using KFCMenu.Models;
using KFCMenu.Services;
using KFCMenu.Stores;
using KFCMenu.ViewModel.Base;
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
        private DishCart _cartItems;
        public DishCart CartItems { get => _cartItems; set => Set(ref _cartItems, value); }


        #region -------------------------------------------SelectedFoodType-------------------------------------------
        private FoodType _SelectedFoodType;

        public FoodType SelectedFoodType
        {
            get => _SelectedFoodType;
            set => Set(ref _SelectedFoodType, value);
        }
        #endregion


        #region -------------------------------------------SelectedPages-------------------------------------------

        private FoodType _Combos;
        public FoodType Combos { get => _Combos; set => Set(ref _Combos, value); }

        private FoodType _Burgers;
        public FoodType Burgers { get => _Burgers; set => Set(ref _Burgers, value); }

        private FoodType _Chickens;
        public FoodType Chickens { get => _Chickens; set => Set(ref _Chickens, value); }


        private FoodType _Drinks;
        public FoodType Drinks { get => _Drinks; set => Set(ref _Drinks, value); }


        #endregion


        #region -------------------------------------------Food In Cart Count-------------------------------------------
        private int _FoodInCartCount ;
        public int FoodInCartCount { get => _FoodInCartCount; set => Set(ref _FoodInCartCount, value); }
        #endregion


        #region -------------------------------------------Commands-------------------------------------------
        
        public ICommand ChangePage { get;  }

        private bool CanChangePageExecuted(object p) => p is FoodType;
        private void OnChangePageExecute(object p)
        {
            SelectedFoodType = (FoodType)p;
        }


        public ICommand AddDishToCart { get;  }

        private bool CanAddDishToCartExecuted(object p) => p is Dish;
        private void OnAddDishToCartExecute(object p) 
        {
            var dish = (Dish)p;
            var cartItem = new CartItem(1,dish);
            CartItems.Add(cartItem,1);
            FoodInCartCount = FoodInCartCount + 1; 
        }


        public ICommand NavigateToCartViewModel { get; }




        #endregion


        public MenuPageViewModel(NavigationStore navigationStore,DishCart? cartItems)
        {
            CartItems = cartItems ?? new DishCart();
            FoodInCartCount = CartItems.Count;
            
            #region InitCommands
            ChangePage = new LambdaCommand(OnChangePageExecute, CanChangePageExecuted);
            AddDishToCart = new LambdaCommand(OnAddDishToCartExecute, CanAddDishToCartExecuted);
            NavigateToCartViewModel = new NavigationCommand<CartViewModel>(navigationStore, () => new CartViewModel(navigationStore, CartItems));
            #endregion
            _Initialize();
        }


        private async void _Initialize()
        {
            var jsonReader = new JsonDataService<Dish>();

            #region combosInit
            var comboList = await Load(jsonReader, GetPath("data.json"));
            Combos = new FoodType() { Title = "Combos", Diches = comboList };
            SelectedFoodType = Combos;
            #endregion

            #region BurgerInit
            Burgers = new FoodType() { Title = "Burgers", Diches = await Load(jsonReader, GetPath("Burgers.json")) };
            #endregion

            #region ChickensInit
            Chickens = new FoodType() { Title = "Chickens", Diches = await Load(jsonReader, GetPath("Chickens.json")) };
            #endregion

            #region DrinksInit
            Drinks = new FoodType() { Title = "Drinks", Diches = await Load(jsonReader, GetPath("Drinks.json")) };
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
