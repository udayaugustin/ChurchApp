using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class AdminMeetingManageViewModel
    {
        public Meeting MeetingItem { get; set; }

        public ICommand SubmitCommand { get; set; }

        private Service service = new Service();
        private IPageService pageService;

        public AdminMeetingManageViewModel(Meeting eventItem, IPageService pageService)
        {
            MeetingItem = eventItem;
            this.pageService = pageService;

            if (string.IsNullOrEmpty(MeetingItem.EventName))
            {
                MeetingItem = new Meeting { StartDate = DateTime.Today, EndDate = DateTime.Today };
            }
            SubmitCommand = new Command(async () => await SubmitAsync());
        }

        private async Task SubmitAsync()
        {
            int? id = MeetingItem.Id;
            if (id != 0)
            {
                await service.UpdateMeetingAsync(MeetingItem);
            }
            else
            {
                await service.CreateMeetingAsync(MeetingItem);
            }
            await pageService.PopAsync();
        }
    }
}
