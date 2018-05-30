using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class EventListViewModel : INotifyPropertyChanged
    {
        private Service service = new Service();
        private ObservableCollection<Events> eventList = new ObservableCollection<Events>();
        private IPageService pageService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavigateToDetailView { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand NavigateToHome { get; set; }        

        public ObservableCollection<Events> EventList
        {
            get { return eventList; }
            set
            {
                eventList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventList"));
            }
        }

        public EventListViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            NavigateToDetailView = new Command<Events>(async ev => await GoToDetailViewAsync(ev));
            EditCommand = new Command<Events>(async ev => await GoToEditView(ev));
            DeleteCommand = new Command<Events>(async ev => await DeleteEventAsync(ev));
            AddCommand = new Command(async () => await AddEventAsync());
            NavigateToHome = new Command(async () => await GoToHome());
        }

        public async Task GetEvents()
        {
            EventList = await service.GetEvents();
        }

        private async Task GoToDetailViewAsync(Events selectedItem)
        {
            await pageService.PushAsync(new EventDetailPage(selectedItem));
        }

        private async Task GoToEditView(Events editItem)
        {
            await pageService.PushAsync(new ManageEvents(editItem));
        }

        private async Task DeleteEventAsync(Events eventItem)
        {
            await service.DeleteEventAsync(eventItem);
            eventList.Remove(eventItem);
        }

        private async Task AddEventAsync()
        {
            await pageService.PushAsync(new ManageEvents(new Events()));
        }

        private async Task GoToHome()
        {

            await pageService.PushAsync(new StartPage());
        }
    }
}
