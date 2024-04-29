using System;

namespace Managers.Models;
    public class Order
    {
        public int? OrderId { get; set; }
        public string? PackageId { get; set; }
        public DateTime ShipDate { get; set; }
        
        public DateTime DeliveryDate { get; set; }
        public int AccountId { get; set; }
        public Address ShippedFrom { get; set; }
        public Address ShippedTo { get; set; }

        public Order(int? orderId, string? packageId, DateTime shipDate, DateTime deliveryDate, int accountId, Address shippedFrom, Address shippedTo)
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

