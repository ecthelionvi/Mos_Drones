using System;

namespace Managers.Models
{
    public class Address
    {
        public int addressId { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string addressLine { get; set; }

        public Address(int addressId, string city, string state, string zipCode, string addressLine)
        {
            this.addressId = addressId;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.addressLine = addressLine;
        }
    }
}
