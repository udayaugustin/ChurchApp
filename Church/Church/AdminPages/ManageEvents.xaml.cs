using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManageEvents : ContentPage
	{
		public ManageEvents(Events eventItem)
		{
			InitializeComponent();

            BindingContext = new ManageEventViewModel(eventItem, new PageService());
		}        
    }
}