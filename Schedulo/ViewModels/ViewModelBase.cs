using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Schedulo.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public bool Disposed;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase()
        {

        }

        ~ViewModelBase()
        {
            Disposed = false;
        }

        public void Dispose()
        {
            Disposed = true;
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (this.Disposed)
            {
                return;
            }

            // If disposing is true -> release manage resource
            if (disposing)
            {
                PropertyChanged = null;
            }

            this.Disposed = true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
