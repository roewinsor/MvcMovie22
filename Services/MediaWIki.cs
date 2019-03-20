using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MvcMovie.Services
{
    public class MediaWIki  
    {
        public async Task<string> GetMovieWikiDetails(string movieTitle, int? pageId)
        {
            // ... Target page.
            string page = "https://en.wikipedia.org/w/api.php?action=query&prop=extracts&exintro=true&titles=";
          
            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page + movieTitle + "&format=json"))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                    result.Length >= 50)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
