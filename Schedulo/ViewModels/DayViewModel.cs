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
        public ObservableCollection<EventViewModel> Events { get; } = new ObservableCollection<EventViewModel>();
    }

    public class EventViewModel
    {
        public string Name { get; set; }
    }

    
}
