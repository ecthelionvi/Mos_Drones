using System;
using System.Reflection.Emit;

namespace Managers.Models;

    public class Depot
    {
        public int DepotId { get; set; }
        public Address DepotAddress { get; set; }

        public Depot(int depotId, Address depotAddress)
        {
            this.DepotId = depotId;
            this.DepotAddress = depotAddress;
        }

        public override string ToString()
        {
            return $"depotId: {DepotId}\n{DepotAddress}";
        }

    }

