using System;

using Xamarin.Forms;

namespace Church
{
    public class AdminMenu : ContentPage
    {
		private AdminMenuViewModel viewModel;
		public AdminMenu() : base()
        {
			viewModel = new AdminMenuViewModel(new PageService());

			this.ToolbarItems.Add(new ToolbarItem() { Text = "Add Event", Priority = 0, Order = ToolbarItemOrder.Secondary, Command=viewModel.AddCommand });
			this.ToolbarItems.Add(new ToolbarItem() { Text = "Home", Priority = 0, Order = ToolbarItemOrder.Secondary, Command=viewModel.NavigateToHome });
        }
    }
}

