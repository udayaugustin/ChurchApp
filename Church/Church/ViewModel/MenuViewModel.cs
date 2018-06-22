using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class MenuViewModel
    {
        private IPageService pageService;

        public ICommand VideoPageCommand { get; set; }

        public ICommand PrayerMeetingPageCommand { get; set; }

        public ICommand ChurchMeetingPageCommand { get; set; }

        public ICommand AdminPageCommad { get; set; }

        public MenuViewModel(IPageService pageService)
        {
            this.pageService = pageService;

            VideoPageCommand = new Command(NavigateToVideosPage);
            ChurchMeetingPageCommand = new Command(NavigateToChurchMeetingPage);
            PrayerMeetingPageCommand = new Command(NavigateToPrayerMeetingPage);
            AdminPageCommad = new Command(NavigateToAdminPage);
        }

        private void NavigateToVideosPage()
        {
            pageService.UpdatePresentNavigationPage(new VideoPage());
        }

        private void NavigateToChurchMeetingPage()
        {
            pageService.UpdatePresentNavigationPage(new MeetingsPage(TableConstants.ChurchMeetingType));
        }

        private void NavigateToPrayerMeetingPage()
        {
            pageService.UpdatePresentNavigationPage(new MeetingsPage(TableConstants.PrayerMeetingType));
        }

        private void NavigateToAdminPage()
        {
            pageService.UpdatePresentNavigationPage(new AdminPage());
        }
    }
}
