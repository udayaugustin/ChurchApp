using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class MeetingDetailViewModel
    {
        private IPageService pageService;

        public Meeting EventItem { get; set; }

        public ICommand GoBack { get; set; }

        public MeetingDetailViewModel(Meeting eventItem, IPageService pageService)
        {
            EventItem = eventItem;
            GoBack = new Command(GoBackToPreviousPage);
            this.pageService = pageService;
        }

        public void GoBackToPreviousPage()
        {
            pageService.PopAsync();
        }
    }
}
