using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church
{
    public class Meeting
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string EventTime
        {
            get
            {
                return StartTime + "-" + EndTime;
            }
        }

        public string EventDetail { get; set; }
    }
}
