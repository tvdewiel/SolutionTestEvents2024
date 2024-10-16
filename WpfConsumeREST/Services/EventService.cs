using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfConsumeREST.Model;

namespace WpfConsumeREST.Services
{
    public class EventService
    {
        private HttpClient client;

        public EventService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5188/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Event> GetEventAsync(string path)
        {
            try
            {
                Event ev = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    ev = await response.Content.ReadAsAsync<Event>();
                }
                return ev;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
