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
    public partial class MeetingsPage : ContentPage
    {
        public MeetingsPage(string meetingType)
        {
            BindingContext = new MeetingsViewModel(new PageService(), meetingType);
            InitializeComponent();            
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as MeetingsViewModel).GetEvents();            
            base.OnAppearing();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            (BindingContext as MeetingsViewModel).NavigateToDetailView.Execute(e.SelectedItem);
        }
    }
}