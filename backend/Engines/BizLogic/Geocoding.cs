using System;
using System.Net.Http;
using Managers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace Engines
{

    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Geocoding
    {

        static HttpClient client = new HttpClient();
        
        static async Task RunAsync(Address address)
        {
            var baseAddress = new Uri("https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf6248457f96ecbcb840598abd640afc8f4a42");
            string myAddress = (address.AddressLine + ", " + address.City + ", " + address.State);
            string encodedAddress = Uri.EscapeDataString(myAddress);
            var myUri = new Uri(baseAddress, $"&text={encodedAddress}");
            client.BaseAddress = myUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task<Coordinate> GetCoordinatesAsync(string path)
        {

            Coordinate coord = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                coord = await response.Content.ReadAsStringAsync<Coordinate>();
            }

            return coord;
        }
    }
}