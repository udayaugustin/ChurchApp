using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsList : ContentPage
    {
        public EventsList()
        {
            BindingContext = new EventListViewModel(new PageService());
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as EventListViewModel).GetEvents();
            base.OnAppearing();            
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as EventListViewModel).NavigateToDetailView.Execute(e.SelectedItem);
        }        
    }
}