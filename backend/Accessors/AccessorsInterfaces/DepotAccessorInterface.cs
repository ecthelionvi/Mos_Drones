using System.Data.SqlClient;
using System.Security.Principal;
using Accessors.DBModels;

namespace Accessors.Accessor
{
    interface IDepotAccessor
    {
        public static DepotDataModel GetDepotWithDepotId(int depotId);
        public static List<DepotDataModel> GetDepotList();
    }
}