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
    
    public string Status { get; set; }

    public OrderDataModel(int? orderId, string? packageId, DateTime shipDate, DateTime deliveryDate, int accountId, AddressDataModel shippedFrom, AddressDataModel shippedTo, string status)
    {
        this.OrderId = orderId;
        this.PackageId = packageId;
        this.ShipDate = shipDate;
        this.DeliveryDate = deliveryDate;
        this.AccountId = accountId;
        this.ShippedFrom = shippedFrom;
        this.ShippedTo = shippedTo;
        this.Status = status;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        OrderDataModel other = (OrderDataModel)obj;
        return (OrderId == other.OrderId && PackageId == other.PackageId && ShipDate.Equals(other.ShipDate)
                && DeliveryDate.Equals(other.DeliveryDate) && AccountId == other.AccountId
                && ShippedFrom.Equals(other.ShippedFrom) && ShippedTo.Equals(other.ShippedTo));
    }

    public override string ToString()
    {
        return $"orderId: {OrderId}\nPackage Id (for tracking): {PackageId}\n{AccountId}Shipped from:\n{ShippedFrom}Shipped To:\n{ShippedTo}\n";
    }
}
