using Schedulo.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Schedulo.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        #region ViewModels
        public MonthViewModel MonthViewModel { get; set; }
        public WeekViewModel WeekViewModel { get; set; }
        public DayViewModel DayViewModel {  get; set; }
        #endregion

        #region Command

        /// <summary>
        /// Window Size Command
        /// </summary>
        public DelegateCommand WindowSizeCommand { get; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            MonthViewModel = new MonthViewModel();
            WeekViewModel = new WeekViewModel();
            DayViewModel = new DayViewModel();

            WindowSizeCommand = new DelegateCommand(WindowSizeChanged, _ => true);
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

        #region Private Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void WindowSizeChanged(object param)
        {
            var sizeArgs = param as SizeChangedEventArgs;

            if (sizeArgs != null)
            {
                double newHeight = sizeArgs.NewSize.Height;

                DayViewModel.ScrollHeight = newHeight - 175;
                WeekViewModel.ScrollHeight = newHeight - 175;
            }
        }
        #endregion
    }
}
