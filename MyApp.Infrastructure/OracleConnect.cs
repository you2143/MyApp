using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public class OracleConnect
    {
        public void connect()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
            using (var connectioin = new OracleConnection(ConnectionString))
            {
                connectioin.Open();
            }
        }
    }
}
