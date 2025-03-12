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
        public MonthViewModel MonthViewModel { get; set; }
        public WeekViewModel WeekViewModel { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            MonthViewModel = new MonthViewModel();
            WeekViewModel = new WeekViewModel();
        }

        #region Protected Methods
        protected override void Dispose(bool disposing)
        {
            if (this.Disposed)
            {
                return;
            }

            if (disposing)
            {
                // TO-DO: Dispose
                if (MonthViewModel != null)
                {
                    MonthViewModel.Dispose();
                }
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}
