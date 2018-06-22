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

        public ICommand NavigateToHome { get; set; }        

		public AdminMenuViewModel(IPageService pageService)
		{
			this.pageService = pageService;
			AddCommand = new Command(async () => await AddMeetingAsync());
            NavigateToHome = new Command(async () => await GoToHome());
		}

		private async Task AddMeetingAsync()
        {
            await pageService.UpdatePresentNavigationPage(new AdminManageMeetingPage(new Meeting()));
        }

        private async Task GoToHome()
        {
			await pageService.UpdatePresentNavigationPage(new MeetingsPage("church_meetings"));
        }
    }
}
