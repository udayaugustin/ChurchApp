using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminManageMeetingPage : ContentPage
	{
		public AdminManageMeetingPage(Meeting meetingItem)
		{
			InitializeComponent();

            BindingContext = new AdminMeetingManageViewModel(meetingItem, new PageService());
		}        
    }
}