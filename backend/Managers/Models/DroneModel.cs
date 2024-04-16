using System;

namespace Managers.Models;

    public class Drone
    {
        public int DroneId { get; set; }
        public string TransitStatus { get; set; }
        public Order Order { get; set; }
        public Depot? CurrentDepot { get; set; }

        public Drone(int droneId, string transitStatus, Order order, Depot? currentDepot)
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

