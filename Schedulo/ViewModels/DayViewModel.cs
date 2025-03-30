using Schedulo.Command;
using Schedulo.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Schedulo.ViewModels
{
    public class DayViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Date
        /// </summary>
        private DateTime _date;
        
        /// <summary>
        /// Hour
        /// </summary>
        private DateTime _hour;

        /// <summary>
        /// Scroll offset
        /// </summary>
        private double _scrollOffset;

        /// <summary>
        /// Local timezone
        /// </summary>
        private string _gmt;

        /// <summary>
        /// Scroll Height;
        /// </summary>
        private double _scrollHeight;

        #endregion

        #region Properties

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date 
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// Hour
        /// </summary>
        public DateTime Hour
        {
            get => _hour;
            set
            {
                _hour = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Scroll offset
        /// </summary>
        public double ScrollOfset
        {
            get => _scrollOffset;
            set
            {
                _scrollOffset = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Local timezone
        /// </summary>
        public string Gmt
        {
            get => _gmt;
            set
            {
                _gmt = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double ScrollHeight
        {
            get => _scrollHeight;
            set
            {
                _scrollHeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Events list
        /// </summary>
        public ObservableCollection<EventViewModel> Events { get; set; } = new ObservableCollection<EventViewModel>();

        /// <summary>
        /// Hours Blocks
        /// </summary>
        public ObservableCollection<DateTime> HourBlocks { get; set; } = new ObservableCollection<DateTime> { };

        #endregion

        #region Command

        /// <summary>
        /// ScrollCommand
        /// </summary>
        public DelegateCommand ScrollCommand { get; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DayViewModel()
        {
            Date = DateTime.Now;
            ScrollCommand = new DelegateCommand(OnScrollChanged, _ => true);
            LoadHours();

            TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            Gmt = $"GMT{(offset.TotalHours >= 0 ? "+" : "")}{offset.TotalHours}";
            _scrollHeight = AppConst.GRID_HEIGHT;
        }

        #endregion

        /// <summary>
        ///  Load Hour
        /// </summary>
        private void LoadHours()
        {
            HourBlocks.Clear();

            for (int i = 0; i < 24; i++)
            {
                HourBlocks.Add(new DateTime(1, 1, 1, i, 0, 0));
            }
        }

        /// <summary>
        /// Scroll Event Change
        /// </summary>
        /// <param name="obj"></param>
        private void OnScrollChanged(object obj)
        {
            if (obj is ScrollChangedEventArgs args)
            {
                ScrollOfset = args.VerticalOffset;
            }
        }
    }

    /// <summary>
    /// Event View Model
    /// </summary>
    public class EventViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
