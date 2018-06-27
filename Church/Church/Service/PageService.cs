using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Church
{
    public class PageService : IPageService
    {
		private App mainApp;

		public PageService()
		{
			mainApp = (Application.Current as App);
		}
		public async Task UpdatePresentNavigationPage(Page page)
        {
			mainApp.RootPage.IsPresented = false;
			var homePage = mainApp.NavigationPage.Navigation.NavigationStack.First();
			mainApp.NavigationPage.Navigation.InsertPageBefore(page, homePage);
			await mainApp.NavigationPage.Navigation.PopToRootAsync(false);
        }        

        public async Task PopAsync()
        {
            await (Application.Current as App).NavigationPage.Navigation.PopAsync();
        }

		public async Task PushAsync(Page page)
		{            
            await (Application.Current as App).NavigationPage.Navigation.PushAsync(page);            
        }
	}
}
