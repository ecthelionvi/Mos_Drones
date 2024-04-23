using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Services
{
    public class Geocoding
    {
        public async Task MakeRequest()
        {
            // Append the address to the base address to recieve a specific longitude and latitude
            var baseAddress = new Uri("https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf6248457f96ecbcb840598abd640afc8f4a42");

            using(var httpClient = new HttpClient{ BaseAddress = baseAddress}) 
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");

                using(var response = await httpClient.GetAsync("directions"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject(responseData);
                }
            }
        }
    }
}