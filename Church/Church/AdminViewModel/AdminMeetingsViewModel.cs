using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class AdminMeetingsViewModel : INotifyPropertyChanged
    {
        private Service service;
        private ObservableCollection<Meeting> meetingList = new ObservableCollection<Meeting>();
        private IPageService pageService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavigateToDetailView { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand NavigateToHome { get; set; }        

        public ObservableCollection<Meeting> EventList
        {
            get { return meetingList; }
            set
            {
                meetingList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EventList)));
            }
        }

        public AdminMeetingsViewModel(IPageService pageService, string meetingType)
        {
            this.pageService = pageService;
            service = new Service(meetingType);

            NavigateToDetailView = new Command<Meeting>(async ev => await GoToDetailViewAsync(ev));
            EditCommand = new Command<Meeting>(async ev => await GoToMeetingEditView(ev));
            DeleteCommand = new Command<Meeting>(async ev => await DeleteMeetingAsync(ev));
            AddCommand = new Command(async () => await AddMeetingAsync());
            NavigateToHome = new Command(async () => await GoToHome());
        }

        public async Task GetMeetings()
        {
            EventList = await service.GetMeetings();
        }

        private async Task GoToDetailViewAsync(Meeting selectedItem)
        {
            await pageService.PushAsync(new MeetingDetailPage(selectedItem));
        }

        private async Task GoToMeetingEditView(Meeting editItem)
        {
            await pageService.PushAsync(new AdminManageMeetingPage(editItem));
        }

        private async Task DeleteMeetingAsync(Meeting meetingItem)
        {
            await service.DeleteMeetingAsync(meetingItem);
            meetingList.Remove(meetingItem);
        }

        private async Task AddMeetingAsync()
        {
            await pageService.PushAsync(new AdminManageMeetingPage(new Meeting()));
        }

        private async Task GoToHome()
        {
            await pageService.PushAsync(new StartPage());
        }
    }
}
