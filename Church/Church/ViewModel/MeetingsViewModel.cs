using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class MeetingsViewModel : INotifyPropertyChanged
    {
        private Service service;
        private ObservableCollection<Meeting> eventList = new ObservableCollection<Meeting>();
        private IPageService pageService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavigateToDetailView { get; set; }

        public ObservableCollection<Meeting> EventList {
            get { return eventList; }
            set
            {
                eventList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventList"));
            }
        } 

        public MeetingsViewModel(IPageService pageService, string meetingType)
        {
            service = new Service(meetingType);
            this.pageService = pageService;
            NavigateToDetailView = new Command<Meeting>(ev => GoToDetailView(ev));
        }

        public async Task GetEvents()
        {
            EventList = await service.GetMeetings();         
        }

        private void GoToDetailView(Meeting selectedItem)
        {
			pageService.PushAsync(new MeetingDetailPage(selectedItem));
        }
    }
}
