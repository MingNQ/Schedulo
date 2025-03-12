using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedulo.ViewModels
{
    public class DayViewModel
    {
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public ObservableCollection<EventViewModel> Events { get; set; } = new ObservableCollection<EventViewModel>();
    }

    public class EventViewModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
