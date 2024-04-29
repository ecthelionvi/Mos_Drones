namespace Accessors.DBModels;

public class OrderDataModel
{
    public int? OrderId { get; set; }
    public string? PackageId { get; set; }
    public DateTime ShipDate { get; set; }
    
    public DateTime DeliveryDate { get; set; }
    public int AccountId { get; set; }
    public AddressDataModel ShippedFrom { get; set; }
    public AddressDataModel ShippedTo { get; set; }

    public OrderDataModel(int? orderId, string? packageId, DateTime shipDate, DateTime deliveryDate, int accountId, AddressDataModel shippedFrom, AddressDataModel shippedTo)
    {
        this.OrderId = orderId;
        this.PackageId = packageId;
        this.ShipDate = shipDate;
        this.DeliveryDate = deliveryDate;
        this.AccountId = accountId;
        this.ShippedFrom = shippedFrom;
        this.ShippedTo = shippedTo;
    }
}
