using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class AdminMenuViewModel
    {
		private IPageService pageService;

		public ICommand AddCommand { get; set; }

        public ICommand NaviagateToAdminChurchMeetings{ get; set; }

        public ICommand NaviagateToAdminPrayerMeetings { get; set; }

        public ICommand NavigateToHome { get; set; }        

		public AdminMenuViewModel(IPageService pageService)
		{
			this.pageService = pageService;
			AddCommand = new Command(async () => await AddMeetingAsync());
            NavigateToHome = new Command(async () => await GoToHome());
            NaviagateToAdminChurchMeetings = new Command(async () => await GoToChurchMeeting());
            NaviagateToAdminPrayerMeetings = new Command(async () => await GoToPrayerMeeting());
        }

		private async Task AddMeetingAsync()
        {
            await pageService.PushAsync(new AdminManageMeetingPage(new Meeting()));
        }

        private async Task GoToHome()
        {
			await pageService.UpdatePresentNavigationPage(new MeetingsPage(TableConstants.ChurchMeetingType));
        }

        private async Task GoToChurchMeeting()
        {
            await pageService.UpdatePresentNavigationPage(new AdminMeetingPage(TableConstants.ChurchMeetingType));
        }

        private async Task GoToPrayerMeeting()
        {
            await pageService.UpdatePresentNavigationPage(new AdminMeetingPage(TableConstants.PrayerMeetingType));
        }
    }
}
