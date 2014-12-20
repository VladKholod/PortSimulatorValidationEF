using System.Configuration;

namespace PortSimulator.DataAccessLayer.DbConfiguration
{
    public static class Parameters
    {
        public static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["PortDB"].ConnectionString;
    }
}
