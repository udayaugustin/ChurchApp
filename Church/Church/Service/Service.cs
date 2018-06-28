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
        private string baseUrl = "https://ezsbc.com/wp_new/events/";
        private string meetingQuery = "meeting_query.php?";
        private string storyQuery = "message_query.php?";
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
            var content = await client.GetStringAsync(baseUrl + meetingQuery + selectAction);
            var events = JsonConvert.DeserializeObject<ObservableCollection<Meeting>>(content);

            return new ObservableCollection<Meeting>(events.Where(e => e.MeetingType == meetingType));
        }

        public async Task CreateMeetingAsync(Meeting eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);
            await client.PostAsync(baseUrl + meetingQuery + addAction, new StringContent(content));
        }

        public async Task UpdateMeetingAsync(Meeting eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);
            await client.PostAsync(baseUrl + meetingQuery + updateAction, new StringContent(content));
        }

        public async Task DeleteMeetingAsync(Meeting eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);
            await client.PostAsync(baseUrl + meetingQuery + deleteAction, new StringContent(content));
        }

        public async Task AddStory(Story storyItem)
        {
            var content = JsonConvert.SerializeObject(storyItem);
            await client.PostAsync(baseUrl + storyQuery + addAction, new StringContent(content));
        }

        public async Task<ObservableCollection<Story>> GetStories()
        {
            var content = await client.GetStringAsync(baseUrl + storyQuery + selectAction);
            
            return JsonConvert.DeserializeObject<ObservableCollection<Story>>(content);
        }
    }
}
