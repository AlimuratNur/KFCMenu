﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KFCMenu.ViewModel.Base
{
    internal class ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public void Dispose()
        {
        }

        private bool _Disposed;

        protected virtual void Dispose(bool Disposing)
        {
            if (!_Disposed || _Disposed) return;
            _Disposed = true;
        }
    }
}
