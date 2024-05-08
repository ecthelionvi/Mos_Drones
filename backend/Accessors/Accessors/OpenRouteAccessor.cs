using Accessors.DBModels;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;


namespace Accessors.Accessors;

public class OpenRouteAccessor
{
    static HttpClient client = new HttpClient();

    public async Task<Coordinate> GetCoordinatesAsync(AddressDataModel address)
    {
        try
        {
            var baseAddress = new Uri("https://api.openrouteservice.org/geocode/search");
            string apiKey = "5b3ce3597851110001cf6248457f96ecbcb840598abd640afc8f4a42";
            string myAddress = $"{address.AddressLine}, {address.City}, {address.State}";
            string encodedAddress = Uri.EscapeDataString(myAddress);
            var queryParameters = $"?api_key={apiKey}&text={encodedAddress}";
            var requestUri = new Uri(baseAddress, queryParameters);
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<dynamic>();
                
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                GeoJsonData geoJsonData = JsonSerializer.Deserialize<GeoJsonData>(jsonResponse, options);
                double latitude = geoJsonData.Features[geoJsonData.Features.Count - 1].Geometry.Coordinates[1];
                double longitude = geoJsonData.Features[geoJsonData.Features.Count - 1].Geometry.Coordinates[0];
                return new Coordinate(latitude, longitude);
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve coordinates. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}

public class Geometry
{
    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; }
}
public class Feature
{
    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }
}

public class GeoJsonData
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

