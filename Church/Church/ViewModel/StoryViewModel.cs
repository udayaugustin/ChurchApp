using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class StoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Story> _storyList { get; set; }
        public Service service = new Service();

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GetStories;
        
        
        public ObservableCollection<Story> StoryList
        {
            get { return _storyList; }

            set
            {
                _storyList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StoryList)));
            }
        }

        public StoryViewModel()
        {
            GetStories = new Command(async () => await GetStoriesAsync());

            GetStories.Execute(null);
        }

        public async Task GetStoriesAsync()
        {
            StoryList =  await service.GetStories();
        }
    }
}
