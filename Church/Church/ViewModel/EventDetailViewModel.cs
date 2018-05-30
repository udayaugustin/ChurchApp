using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church
{
    public class EventDetailViewModel
    {
        public Events EventItem { get; set; }

        public EventDetailViewModel(Events eventItem)
        {
            EventItem = eventItem;            
        }
    }
}
