using System;

namespace Managers.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public string packageId { get; set; }
        public DateTime shipDate { get; set; }
        public Account account { get; set; }
        public Address shippedFrom { get; set; }
        public Address shippedTo { get; set; }

        public Order(int orderId, string packageId, DateTime shipDate, Account account, Address shippedFrom, Address shippedTo)
        {
            this.orderId = orderId;
            this.packageId = packageId;
            this.shipDate = shipDate;
            this.account = account;
            this.shippedFrom = shippedFrom;
            this.shippedTo = shippedTo;
        }

        public override string ToString()
        {
            return $"orderId: {orderId}\nPackage Id (for tracking): {packageId}\n{account}Shipped from:\n{shippedFrom}Shipped To:\n{shippedTo}\n";
        }
    }
}
