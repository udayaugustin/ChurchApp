using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
    public class EventsViewModel : INotifyPropertyChanged
    {
        private Service service = new Service();
        private ObservableCollection<Events> eventList = new ObservableCollection<Events>();
        private IPageService pageService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavigateToDetailView { get; set; }

        public ObservableCollection<Events> EventList {
            get { return eventList; }
            set
            {
                eventList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventList"));
            }
        } 

        public EventsViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            NavigateToDetailView = new Command<Events>(ev => GoToDetailView(ev));
        }

        public async Task GetEvents()
        {
            EventList = await service.GetEvents();         
        }

        private void GoToDetailView(Events selectedItem)
        {
            pageService.PushAsync(new EventDetailPage(selectedItem));
        }
    }
}
