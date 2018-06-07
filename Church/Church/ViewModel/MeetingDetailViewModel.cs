using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church
{
    public class MeetingDetailViewModel
    {
        public Meeting EventItem { get; set; }

        public MeetingDetailViewModel(Meeting eventItem)
        {
            EventItem = eventItem;            
        }
    }
}
