using System;

public class Address
{
    private int addressId { get; set; }
    private string city { get; set; }
    private string state { get; set; }
    private string zipCode { get; set; }
    private string addressLine { get; set; }

    public Address(int addressId, string city, string state, string zipCode, string addressLine)
    {
        this.addressId = addressId;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
        this.addressLine = addressLine;
    }
}
