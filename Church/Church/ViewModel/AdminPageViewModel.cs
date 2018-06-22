namespace Church
{
    public class AdminPageViewModel
    {
        private IPageService pageService;

        public AdminPageViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            ValidateUser();
        }

        public void ValidateUser()
        {
            pageService.UpdatePresentNavigationPage(new LoginPage());
        }
    }
}
