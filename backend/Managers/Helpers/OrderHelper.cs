using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class OrderHelper
{
        public static OrderServiceModel DBModelToServiceModel(OrderDBModel dbm)
        {
            return new OrderServiceModel
            {
                Id = dbm.Id,
                Status = dbm.Status,
                DeliveryDate = dbm.DeliveryDate
                // Assign other properties as needed
            };
        }

        public static OrderDBModel ServiceModelToDBModel(OrderServiceModel sm)
        {
            return new OrderDBModel
            {
                Id = sm.Id,
                Status = sm.Status,
                DeliveryDate = sm.DeliveryDate
                // Assign other properties as needed
            };
        }
    }