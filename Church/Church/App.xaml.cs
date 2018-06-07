using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Church
{
    public partial class App : Application
    {
		public NavigationPage NavigationPage { get; private set; }

        public MasterDetailPage RootPage { get; set; }

        public App()
        {
            InitializeComponent();

			var menuPage = new MenuPage();
			NavigationPage = new NavigationPage(new MeetingsPage("church_meetings"));
            
			RootPage = new RootPage();
            RootPage.Master = menuPage;
            RootPage.Detail = NavigationPage;
            
			MainPage = RootPage;                        
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
