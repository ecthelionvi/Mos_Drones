using System;
using System.Reflection.Emit;

namespace Managers.Models
{
    public class Depot
    {
        public int depotId { get; set; }
        public Address depotAddress { get; set; }

        public Depot(int depotId, Address depotAddress)
        {
            this.depotId = depotId;
            this.depotAddress = depotAddress;
        }

        public override string ToString()
        {
            return $"depotId: {depotId}\n{depotAddress}";
        }

    }
}
