using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFCMenu.ViewModel.Base;

namespace KFCMenu.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private int _SelectedPageIndex;
        public int SelectedPageIndex { get { return _SelectedPageIndex; } set { Set(ref _SelectedPageIndex, value); } }
    

    }
}
