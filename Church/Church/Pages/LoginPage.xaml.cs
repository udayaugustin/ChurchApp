using Xamarin.Forms;

namespace Church
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel
        {
            get { return BindingContext as LoginViewModel; }
            set { BindingContext = value; }
        }

        public LoginPage()
        {
            ViewModel = new LoginViewModel(new PageService(), new AppResourceService());            

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.SubmitLogin.Execute(null);

            base.OnAppearing();
        }        
    }
}
