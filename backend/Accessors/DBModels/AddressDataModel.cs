using System.IO;
using System.Net;

namespace Accessors.DBModels;

public class AddressDataModel
{
    public int? AddressId { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string AddressLine { get; set; }
    
    public Coordinate? Coordinates { get; set; }

    public AddressDataModel(int? addressId, string city, string state, string zipCode, string addressLine, Coordinate? coordinates)
    {
        this.AddressId = addressId;
        this.City = city;
        this.State = state;
        this.ZipCode = zipCode;
        this.AddressLine = addressLine;
        this.Coordinates = coordinates;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        AddressDataModel other = (AddressDataModel)obj;
        return (AddressId == other.AddressId && City == other.City && State == other.State
            && ZipCode == other.ZipCode && AddressLine == other.AddressLine);
    }
    public override string ToString()
    {
        return $"addressId: {AddressId}\n{AddressLine}, {City}, {State} {ZipCode}\nCoordinates: ({Coordinates.Latitude}, {Coordinates.Longitude})\n";
    }
}
