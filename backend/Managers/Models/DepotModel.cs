using System;

public class Depot
{
    private int depotId { get; set; }
    private Address depotAddress { get; set; }

    public Depot(int depotId, Address depotAddress)
    {
        this.depotId = depotId;
        this.depotAddress = depotAddress;
    }

}
