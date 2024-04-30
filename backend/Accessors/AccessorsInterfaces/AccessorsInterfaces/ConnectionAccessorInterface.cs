using System.Data.SqlClient;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Accessors.ConnectionAccessor
{
    interface IConnectionAccessor
    {
        public static SqlConnection GetConnection();
        static void Main(string[] args);
    }
}