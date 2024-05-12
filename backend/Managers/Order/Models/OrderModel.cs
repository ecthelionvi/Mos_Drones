using System;
using Engines.BizLogic;

namespace Managers.Order.Models;
    public class Order
    {
        public int? OrderId { get; set; }
        public string? PackageId { get; set; }
        public DateTime ShipDate { get; set; }
        
        public DateTime DeliveryDate { get; set; }
        public int AccountId { get; set; }
        public Address.Address ShippedFrom { get; set; }
        public Address.Address ShippedTo { get; set; }
        public string Status { get; set; }
        

        public Order(int? orderId, string? packageId, DateTime shipDate, DateTime deliveryDate, int accountId, Address.Address shippedFrom, Address.Address shippedTo, string status)
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
    }

