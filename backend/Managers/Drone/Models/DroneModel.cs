using System;

namespace Managers.Drone.Models;

    public class Drone
    {
        public int DroneId { get; set; }
        public string TransitStatus { get; set; }
        public Order.Models.Order? Order { get; set; }
        public Depot.Depot? CurrentDepot { get; set; }

        public Drone(int droneId, string transitStatus, Order.Models.Order order, Depot.Depot? currentDepot)
        {
            this.DroneId = droneId;
            this.TransitStatus = transitStatus;
            this.Order = order;
            this.CurrentDepot = currentDepot;
        }

        public override string ToString()
        {
            return $"droneId: {DroneId}\nTransit Status: {TransitStatus}\n{Order}{CurrentDepot}";
        }
    }

