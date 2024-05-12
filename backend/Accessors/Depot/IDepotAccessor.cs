using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.Depot.Models;

namespace Accessors.Depot
{
    public interface IDepotAccessor
    {
        DepotDataModel GetDepotWithDepotId(int depotId);
        List<DepotDataModel> GetDepotList();
    }
}