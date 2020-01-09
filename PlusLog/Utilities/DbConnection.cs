using PlusLog.Config.Xml.Database;

namespace PlusLog.Utilities
{
    internal class DbConnection
    {
        public static string GetConnectionString(Connection connection)
        {
            return "Data Source = " + connection.Server + "; Initial Catalog = " + connection.Database + "; Persist Security Info=True; User ID = " + connection.User + "; Password=" + connection.Password;
        }
    }
}
