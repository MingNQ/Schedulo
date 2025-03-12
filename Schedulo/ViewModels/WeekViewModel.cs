using Schedulo.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Schedulo.ViewModels
{
    internal class WeekViewModel : ViewModelBase
    {
        /// <summary>
        /// List of day
        /// </summary>
        private ObservableCollection<DayViewModel> _days;

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
        /// List of Hour
        /// </summary>
        private ObservableCollection<DayViewModel> _hourBlocks;

        /// <summary>
        /// List of Hour
        /// </summary>
        public ObservableCollection<DayViewModel> HourBlocks
        {
            get
            {
                if (_hourBlocks == null)
                {
                    _hourBlocks = new ObservableCollection<DayViewModel>();
                }

                return _hourBlocks;
            }
            set
            {
                _hourBlocks = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Time in Day
        /// </summary>
        private ObservableCollection<DayViewModel> _timeSlots;

        public ObservableCollection<DayViewModel> TimeSlots
        {
            get
            {
                if (_timeSlots == null)
                {
                    _timeSlots = new ObservableCollection<DayViewModel>();
                }

                return _timeSlots;
            }
            set
            {
                _timeSlots = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Current Date
        /// </summary>
        private DateTime _currentDate;

        /// <summary>
        /// Current Date
        /// </summary>
        public DateTime CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged();
                LoadDays();
            }
        }

        private double _scrollOffset;
        public double ScrollOfset
        {
            get => _scrollOffset;
            set
            {
                _scrollOffset = value;
                OnPropertyChanged();
            }
        }

        private string _gmt;
        public string Gmt
        {
            get => _gmt;
            set
            {
                _gmt = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand ScrollCommand { get; set; }

        public WeekViewModel()
        {
            CurrentDate = DateTime.Now;
            ScrollCommand = new DelegateCommand(OnScrollChanged, _ => true);
            LoadDays();
            LoadHours();
            LoadTimeSlots();

            TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            Gmt = $"GMT{(offset.TotalHours >= 0 ? "+" : "")}{offset.TotalHours}";
        }

        private void OnScrollChanged(object obj)
        {
            if (obj is ScrollChangedEventArgs args)
            {
                ScrollOfset = args.VerticalOffset;
            }
        }

        private void LoadDays()
        {
            Days = new ObservableCollection<DayViewModel>();

            int startDayOfWeek = (int)CurrentDate.DayOfWeek;
            DateTime startDate = CurrentDate.AddDays(-startDayOfWeek);

            for (int i = 0; i < 7; i++)
            {
                Days.Add(new DayViewModel
                {
                    Date = startDate.AddDays(i)
                });
            }
        }

        private void LoadHours()
        {
            HourBlocks.Clear();

            for (int i = 1; i < 24; i++)
            {
                HourBlocks.Add(new DayViewModel
                {
                    Hour = new DateTime(1, 1, 1, i, 0, 0)
                });
            }
        }

        private void LoadTimeSlots()
        {
            TimeSlots = new ObservableCollection<DayViewModel>();

            for (int i = 0; i < 7 * 24; i++)
            {
                TimeSlots.Add(new DayViewModel
                {
                    Events = new ObservableCollection<EventViewModel>()
                });
            }
        }
    }
}
