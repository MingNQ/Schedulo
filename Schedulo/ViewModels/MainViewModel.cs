using Schedulo.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schedulo.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        protected override void Dispose(bool disposing)
        {
            if (this.Disposed)
            {
                return;
            }

            if (disposing)
            {
                // TO-DO: Dispose
            }

            base.Dispose(disposing);
        }
    }
}
