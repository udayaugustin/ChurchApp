using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Church
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        public EventsPage()
        {
            BindingContext = new EventsViewModel(new PageService());
            InitializeComponent();            
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as EventsViewModel).GetEvents();            
            base.OnAppearing();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            (BindingContext as EventsViewModel).NavigateToDetailView.Execute(e.SelectedItem);
        }
    }
}