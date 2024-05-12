using System.Text.Json.Serialization;

namespace Accessors.API.OpenRoute.Models;

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