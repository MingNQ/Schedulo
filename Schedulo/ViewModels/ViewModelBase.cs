using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            if (!this.Disposed)
            {
                if (disposing)
                {
                    // TO-DO: Dispose
                }
            }

            this.Disposed = true;
        }
    }
}
