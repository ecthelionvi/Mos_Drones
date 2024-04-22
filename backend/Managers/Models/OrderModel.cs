using System;

namespace Managers.Models;
    public class Order
    {
        public int OrderId { get; set; }
        public string PackageId { get; set; }
        public DateTime ShipDate { get; set; }
        
        public DateTime DeliveryDate { get; set; }
        public Account Account { get; set; }
        public Address ShippedFrom { get; set; }
        public Address ShippedTo { get; set; }

        public Order(int orderId, string packageId, DateTime shipDate, DateTime deliveryDate, Account account, Address shippedFrom, Address shippedTo)
        {
            this.OrderId = orderId;
            this.PackageId = packageId;
            this.ShipDate = shipDate;
            this.DeliveryDate = deliveryDate;
            this.Account = account;
            this.ShippedFrom = shippedFrom;
            this.ShippedTo = shippedTo;
        }

        public override string ToString()
        {
            return $"orderId: {OrderId}\nPackage Id (for tracking): {PackageId}\n{Account}Shipped from:\n{ShippedFrom}Shipped To:\n{ShippedTo}\n";
        }
    }

