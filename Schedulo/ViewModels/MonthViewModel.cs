using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedulo.ViewModels
{
    internal class MonthViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// List of day
        /// </summary>
        private ObservableCollection<DayViewModel> _days;
        #endregion

        #region Properties

        /// <summary>
        /// List of day
        /// </summary>
        public ObservableCollection<DayViewModel> Days
        {
            get
            {
                if (_days == null)
                {
                    _days = new ObservableCollection<DayViewModel>();
                }

                return _days;
            }
            set
            {
                _days = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Current Month
        /// </summary>
        public DateTime CurrentMonth { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MonthViewModel()
        {
            CurrentMonth = DateTime.Today;
            LoadDays();
        }

        /// <summary>
        /// Load days to view
        /// </summary>
        private void LoadDays()
        {
            Days = new ObservableCollection<DayViewModel>();

            DateTime firstDayOfMonth = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            DateTime startDate = firstDayOfMonth.AddDays(-startDayOfWeek);

            for (int i = 0; i < 42; i++)
            {
                Days.Add(new DayViewModel
                {
                    Date = startDate.AddDays(i)
                });
            }
        }
    }
}
