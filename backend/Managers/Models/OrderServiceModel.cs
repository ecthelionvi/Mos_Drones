using System.Runtime.InteropServices;

namespace Managers.Models;

public class OrderServiceModel
{
    public string Id { get; set; }
    
    public string DeliveryDate { get; set; }
    
    public string Status { get; set; }
}