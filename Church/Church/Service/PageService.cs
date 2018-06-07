﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace Church
{
    public class PageService : IPageService
    {        
        public async Task PushAsync(Page page)
        {
            (Application.Current as App).RootPage.IsPresented = false;
            await (Application.Current as App).NavigationPage.Navigation.PushAsync(page);            
        }        

        public async Task PopAsync()
        {
			await (Application.Current as App).NavigationPage.Navigation.PopAsync();
        }
    }
}
