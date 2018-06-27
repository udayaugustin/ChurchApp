using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingDetailPage : ContentPage
    {
        public MeetingDetailPage(Meeting eventItem)
        {
            InitializeComponent();

            BindingContext = new MeetingDetailViewModel(eventItem, new PageService());

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}