using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private User _user = new User();
        private bool _isErrorLabelVisible;
        private IPageService pageService;
        private IAppResource appResourceService;
        private bool isLoginPageVisible;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SubmitLogin { get; private set; }        

        public bool IsLoginPageVisible {
            get { return isLoginPageVisible; }

            set
            {
                isLoginPageVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsLoginPageVisible"));
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            }
        }

        public bool IsErrorLabelVisible
        {
            get { return _isErrorLabelVisible; }
            set
            {
                _isErrorLabelVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsErrorLabelVisible"));
            }
        }

        public LoginViewModel(IPageService pageService, IAppResource appResource)
        {
            this.pageService = pageService;
            this.appResourceService = appResource;
            SubmitLogin = new Command(async vm => await Login());
        }

        private async Task Login()
        {
            IsErrorLabelVisible = false;
            if (ValidateAuthentication(User))
            {
                appResourceService.UpdateLoginStatus(true);                
                await pageService.UpdatePresentNavigationPage(new AdminMeetingPage(TableConstants.ChurchMeetingType));
            }
            else
            {
                IsLoginPageVisible = true;

                if (!string.IsNullOrEmpty(User.UserName))
                    IsErrorLabelVisible = true;
            }
        }

        private bool ValidateAuthentication(User user)
        {
            //Service Call
            if ((user.UserName == "admin" && user.Password == "admin") || appResourceService.IsLoggedIn())
            {
                return true;
            }

            return false;
        }
    }
}
