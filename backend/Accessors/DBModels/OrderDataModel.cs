namespace Accessors.DBModels;

public class OrderDataModel
{
    public int OrderId { get; set; }
    public string PackageId { get; set; }
    public DateTime ShipDate { get; set; }
    public AccountDataModel Account { get; set; }
    public AddressDataModel ShippedFrom { get; set; }
    public AddressDataModel ShippedTo { get; set; }

    public OrderDataModel(int orderId, string packageId, DateTime shipDate, AccountDataModel account, AddressDataModel shippedFrom, AddressDataModel shippedTo)
    {
        this.OrderId = orderId;
        this.PackageId = packageId;
        this.ShipDate = shipDate;
        this.Account = account;
        this.ShippedFrom = shippedFrom;
        this.ShippedTo = shippedTo;
    }
        
    public override string ToString()
    {
        return $"orderId: {OrderId}\nPackage Id (for tracking): {PackageId}\n{Account}Shipped from:\n{ShippedFrom}Shipped To:\n{ShippedTo}\n";
    }
}
