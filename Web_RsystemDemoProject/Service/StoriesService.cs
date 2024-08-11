using System.Net.Http.Headers;
using Web_RsystemDemoProject.Model;
using Newtonsoft.Json;

namespace Web_RsystemDemoProject.Service
{
    public class StoriesService:IStoriesService
    {
        /// <summary>
        ///  return Stories Object from api
        /// </summary>
        /// <param name="id">Id for Stories</param>
        /// <returns>Stories Object</returns>
        public async Task<Stories> GetStories(string id)
        {
            Stories? stories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/item/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(id+".json");
                if (response.IsSuccessStatusCode)
                {
                    var StoriesIds = await response.Content.ReadAsStringAsync();

                    stories = JsonConvert.DeserializeObject<Stories>(Convert.ToString(StoriesIds));

                }
                
            }

            return stories != null ? stories : new Stories();
        }


        /// <summary>
        /// Return list of 500 Best Stories
        /// </summary>
        /// <returns>int List</returns>
        public async Task<IEnumerable<string>> GetStoriesIdList()
        {
            IEnumerable<string> StoriesIdList ;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("/v0/topstories.json?print=pretty");
                if (response.IsSuccessStatusCode)
                {
                    var StoriesIds = await response.Content.ReadAsStringAsync();

                    StoriesIdList = JsonConvert.DeserializeObject<IEnumerable<string>>(Convert.ToString(StoriesIds));

                }
                else
                {
                    StoriesIdList=new List<string>();
                }
            }

            return StoriesIdList!=null?StoriesIdList: new List<string>();
        }
    }
}
