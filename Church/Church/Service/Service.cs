using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Church
{
    public class Service
    {
        private HttpClient client = new HttpClient();
        private string baseUrl = "https://ezsbc.com/wp_new/events/api_query.php?";
        private string selectAction = "action=select";
        private string addAction = "action=insert";
        private string updateAction = "action=update";
        private string deleteAction = "action=delete";

        public async Task<ObservableCollection<Events>> GetEvents()
        {
            var content = await client.GetStringAsync(baseUrl+selectAction);
            var events = JsonConvert.DeserializeObject<ObservableCollection<Events>>(content);

            return events;
        }

        public async Task CreateEventAsync(Events eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);
            await client.PostAsync(baseUrl + addAction, new StringContent(content));
        }

        public async Task UpdateEventAsync(Events eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);            
            await client.PostAsync(baseUrl + updateAction, new StringContent(content));
        }

        public async Task DeleteEventAsync(Events eventItem)
        {
            var content = JsonConvert.SerializeObject(eventItem);            
            await client.PostAsync(baseUrl + deleteAction, new StringContent(content));
        }
    }
}
