using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        public EventDetailPage(Events eventItem)
        {
            InitializeComponent();

            BindingContext = new EventDetailViewModel(eventItem);
        }
    }
}