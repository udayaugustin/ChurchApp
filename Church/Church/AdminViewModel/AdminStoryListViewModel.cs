using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class AdminStoryListViewModel : StoryViewModel
    {
        private IPageService pageService;

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public AdminStoryListViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            EditCommand = new Command<Story>(async story => await GoToStoryEditView(story));
            DeleteCommand = new Command<Story>(async story => await DeleteStory(story));
        }

        private async Task GoToStoryEditView(Story story)
        {
            await pageService.PushAsync(new Stories(story));
        }

        private async Task DeleteStory(Story story)
        {
            StoryList.Remove(story);
            await service.DeleteStoryAsync(story);
        }
    }
}
