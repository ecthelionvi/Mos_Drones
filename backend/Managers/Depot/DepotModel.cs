using System;
using System.Reflection.Emit;

namespace Managers.Depot;

    public class Depot
    {
        public int DepotId { get; set; }
        public Address.Address DepotAddress { get; set; }

        public Depot(int depotId, Address.Address depotAddress)
        {
            this.DepotId = depotId;
            this.DepotAddress = depotAddress;
        }

        public override string ToString()
        {
            return $"depotId: {DepotId}\n{DepotAddress}";
        }

    }

