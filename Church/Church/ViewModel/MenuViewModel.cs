using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class MenuViewModel
    {
		private IPageService pageService;

		public ICommand VideoPageCommad { get; set; }       
        
		public MenuViewModel(IPageService pageService)
		{
			this.pageService = pageService;
			VideoPageCommad = new Command(NavigateToVideosPage);
		}
        
		private void NavigateToVideosPage()
		{
			pageService.PushAsync(new VideoPage());
		}
    }
}
