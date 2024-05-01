using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessor
{
    interface IDepotAccessor
    {
        DepotDataModel GetDepotWithDepotId(int depotId);
        List<DepotDataModel> GetDepotList();
    }
}