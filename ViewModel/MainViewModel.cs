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
        #region ----------------------------------Title----------------------------------
        private string _Title = "KFC Menu Window";
        public string Title { 
            get => _Title; 
            set => Set(ref _Title, value); }
        #endregion

        #region ----------------------------------Current VIew Model----------------------------------
        private ViewModelBase _CurrentViewModel;
        public ViewModelBase CurrentViewModel { 
            get => _CurrentViewModel;
            set => Set(ref _CurrentViewModel, value);}


        #endregion


        public MainViewModel()
        {
            CurrentViewModel = new MenuPageViewModel();
            _Initialize();
        }
        private async void _Initialize()
        {
            
        }
    }
} 
