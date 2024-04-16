namespace Accessors.DBModels;

public class AddressDataModel
{
    public int AddressId { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string AddressLine { get; set; }

    public AddressDataModel(int addressId, string city, string state, string zipCode, string addressLine)
    {
        this.AddressId = addressId;
        this.City = city;
        this.State = state;
        this.ZipCode = zipCode;
        this.AddressLine = addressLine;
    }

}
