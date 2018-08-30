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
    public partial class AdminStoryListPage : AdminMenu
    {
        private AdminStoryListViewModel viewModel;
        public AdminStoryListPage()
        {
            BindingContext = viewModel = new AdminStoryListViewModel(new PageService());

            InitializeComponent();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //(BindingContext as AdminMeetingsViewModel).NavigateToDetailView.Execute(e.SelectedItem);
        }
    }
}