using System.Data.SqlClient;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Accessors.ConnectionAccessor
{
    interface IConnectionAccessor
    {
        SqlConnection GetConnection();
    }
}