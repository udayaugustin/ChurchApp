using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class ManageEventViewModel
    {
        public Events EventItem { get; set; }

        public ICommand SubmitCommand { get; set; }

        private Service service = new Service();
        private IPageService pageService;

        public ManageEventViewModel(Events eventItem, IPageService pageService)
        {
            EventItem = eventItem;
            this.pageService = pageService;

            if (string.IsNullOrEmpty(EventItem.EventName))
            {
                EventItem = new Events { StartDate = DateTime.Today, EndDate = DateTime.Today };
            }
            SubmitCommand = new Command(async () => await SubmitAsync());
        }

        private async Task SubmitAsync()
        {
            int? id = EventItem.Id;
            if (id != 0)
            {
                await service.UpdateEventAsync(EventItem);
            }
            else
            {
                await service.CreateEventAsync(EventItem);
            }
            await pageService.PopAsync();
        }
    }
}
