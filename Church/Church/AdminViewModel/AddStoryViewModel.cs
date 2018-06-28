using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class AddStoryViewModel
    {
        private Service service = new Service();
        private IPageService pageService;
        public Story StoryItem { get; set; }

        public ICommand SubmitCommand { get; set; }

        public AddStoryViewModel(Story story, IPageService pageService)
        {
            StoryItem = story;
            this.pageService = pageService;
            SubmitCommand = new Command(async () => await SubmitAsync());
        }

        private async Task SubmitAsync()
        {
            await service.AddStory(StoryItem);
            await pageService.PopAsync();
        }
    }
}
