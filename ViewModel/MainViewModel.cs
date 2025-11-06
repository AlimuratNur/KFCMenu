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
using KFCMenu.Stores;



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
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel { 
            get => _navigationStore.CurrentViewModel;}


        #endregion


        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
} 
