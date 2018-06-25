using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Church
{
	public class AdminMeetingManageViewModel : INotifyPropertyChanged
    {        
		private Service service = new Service();
        private IPageService pageService;
		private int selectedMeetingIndex;
		private List<string> meetingTypeList = new List<string>
        {
            TableConstants.ChurchMeetingType,
            TableConstants.PrayerMeetingType
        };

		public event PropertyChangedEventHandler PropertyChanged;

		public Meeting MeetingItem { get; set; }

        public ICommand SubmitCommand { get; set; }                

		public List<string> MeetingTypeList => meetingTypeList;

		public int SelectedMeetingIndex { 
			get { return selectedMeetingIndex; }

			set
			{
				if(selectedMeetingIndex != value)
				{
					selectedMeetingIndex = value;
                    
					if(PropertyChanged != null)
					{
						PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMeetingIndex)));	
					}
                    
					MeetingItem.MeetingType = MeetingTypeList[selectedMeetingIndex];
				}
			}
		}

		public AdminMeetingManageViewModel(Meeting eventItem, IPageService pageService)
        {
            MeetingItem = eventItem;
            this.pageService = pageService;           

            if (string.IsNullOrEmpty(MeetingItem.EventName))
            {
                MeetingItem = new Meeting { StartDate = DateTime.Today, EndDate = DateTime.Today };
			}else
			{
				SelectedMeetingIndex = meetingTypeList.IndexOf(MeetingItem.MeetingType);
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
