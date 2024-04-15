using System;

namespace Managers.Models
{
    public class Drone
    {
        public int droneId { get; set; }
        public string transitStatus { get; set; }
        public Order order { get; set; }
        public Depot? currentDepot { get; set; }

        public Drone(int droneId, string transitStatus, Order order, Depot? currentDepot)
        {
            this.droneId = droneId;
            this.transitStatus = transitStatus;
            this.order = order;
            this.currentDepot = currentDepot;
        }

        public override string ToString()
        {
            return $"droneId: {droneId}\nTransit Status: {transitStatus}\n{order}{currentDepot}";
        }
    }
}
