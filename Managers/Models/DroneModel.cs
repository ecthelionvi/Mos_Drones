using System;

public class Drone
{
    private int droneId {  get; set; }
    private string transitStatus { get; set; }
    private Order order { get; set; }
    private Depot currentDepot { get; set; }

    public Drone(int droneId, string transitStatus, Order order, Depot currentDepot)
    {
        this.droneId = droneId;
        this.transitStatus = transitStatus;
        this.order = order;
        this.currentDepot = currentDepot;
    }
}
