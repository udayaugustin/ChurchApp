using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Church
{
    public class Service
    {
        private HttpClient client = new HttpClient();
        private string baseUrl = "https://ezsbc.com/wp_new/events/meeting_query.php?";
        private string selectAction = "action=select";
        private string addAction = "action=insert";
        private string updateAction = "action=update";
        private string deleteAction = "action=delete";
        private string meetingType;

        public Service()
        {

        }

        public Service(string meetingType)
        {
            this.meetingType = meetingType;
            //baseUrl += "meetingType=" + meetingType+"&";
        }

        public async Task<ObservableCollection<Meeting>> GetMeetings()
        {
            var content = await client.GetStringAsync(baseUrl+selectAction);
            var events = JsonConvert.DeserializeObject<ObservableCollection<Meeting>>(content);

			return new ObservableCollection<Meeting>(events.Where(e => e.MeetingType == meetingType));
        }

        public async Task CreateMeetingAsync(Meeting eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);
            await client.PostAsync(baseUrl + addAction, new StringContent(content));
        }

        public async Task UpdateMeetingAsync(Meeting eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);            
            await client.PostAsync(baseUrl + updateAction, new StringContent(content));
        }

        public async Task DeleteMeetingAsync(Meeting eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);            
            await client.PostAsync(baseUrl + deleteAction, new StringContent(content));
        }
    }
}
