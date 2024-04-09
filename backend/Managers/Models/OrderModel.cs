using System;

public class Order
{
    private int orderId { get; set; }
    private string packageId { get; set; }
    private DateTime shipDate { get; set; }
    private User user { get; set; }
    private Address shippedFrom { get; set; }
    private Address shippedTo { get; set; }

    public Order(int orderId, string packageId, DateTime shipDate, User user, Address shippedFrom, Address shippedTo)
    {
        this.orderId = orderId;
        this.packageId = packageId;
        this.shipDate = shipDate;
        this.user = user;
        this.shippedFrom = shippedFrom;
        this.shippedTo = shippedTo;
    }
}
