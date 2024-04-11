using System;

namespace Managers
{
    public class Order
    {
        public int orderId { get; set; }
        public string packageId { get; set; }
        public DateTime shipDate { get; set; }
        public User user { get; set; }
        public Address shippedFrom { get; set; }
        public Address shippedTo { get; set; }

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
}
