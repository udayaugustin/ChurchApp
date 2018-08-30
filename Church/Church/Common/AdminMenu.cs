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

			this.ToolbarItems.Add(new ToolbarItem() { Text = "Add Meeting", Priority = 0, Order = ToolbarItemOrder.Secondary, Command=viewModel.AddCommand });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Edit Church Meetings", Priority = 0, Order = ToolbarItemOrder.Secondary, Command = viewModel.NaviagateToAdminChurchMeetings });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Edit Prayer Meetings", Priority = 0, Order = ToolbarItemOrder.Secondary, Command = viewModel.NaviagateToAdminPrayerMeetings });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Add Story", Priority = 0, Order = ToolbarItemOrder.Secondary, Command = viewModel.AddStoryCommand });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Edit Story", Priority = 0, Order = ToolbarItemOrder.Secondary, Command = viewModel.NaviagateToAdminStory });
            this.ToolbarItems.Add(new ToolbarItem() { Text = "Home", Priority = 0, Order = ToolbarItemOrder.Secondary, Command=viewModel.NavigateToHome });
        }
    }
}

