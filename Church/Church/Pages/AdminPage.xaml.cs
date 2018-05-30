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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            BindingContext = new AdminPageViewModel(new PageService());
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (BindingContext as AdminPageViewModel).ValidateUser();
        }

        
    }
}