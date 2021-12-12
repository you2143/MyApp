using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace MyApp.Infrastructure
{
    public static class ConnectionInstance
    {
        private static OracleConnection m_connection;
        public static OracleConnection Connection
        {
            get
            {
                if (m_connection is null)
                {
                    m_connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString);
                    m_connection.Open();
                    return m_connection;
                }
                else
                {
                    if (m_connection.State == System.Data.ConnectionState.Closed)
                    {
                        m_connection.Open();
                    }
                    return m_connection;
                }
            }
        }
    }
}
