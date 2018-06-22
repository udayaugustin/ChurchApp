using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminMeetingPage : AdminMenu
    {
        public AdminMeetingPage(string meetingType)
        {
            BindingContext = new AdminMeetingsViewModel(new PageService(), meetingType);
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as AdminMeetingsViewModel).GetMeetings();
            base.OnAppearing();            
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as AdminMeetingsViewModel).NavigateToDetailView.Execute(e.SelectedItem);
        }        
    }
}