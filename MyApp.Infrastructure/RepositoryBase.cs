using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    /// <summary>リポジトリベース</summary>
    public class RepositoryBase
    {
        /// <summary>コネクション</summary>
        private OracleConnection connection;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RepositoryBase()
        {
            connection = ConnectionInstance.Connection;
        }

        public IDataReader ExecuteReader(string sql)
        {
            return this.ExecuteReader(sql, null);
        }

        public IDataReader ExecuteReader(string sql, IEnumerable<KeyValuePair<string, object>> parameter = null)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.BindByName = true;
                foreach (var x in parameter ?? new List<KeyValuePair<string, object>>())
                {
                    var param = command.CreateParameter();
                    param.ParameterName = x.Key;
                    param.Value = x.Value;
                    command.Parameters.Add(param);
                };
                return command.ExecuteReader();
            }
        }

        public void ExecuteNonQuery(string sql)
        {
             ExecuteNonQuery(sql, null);
        }

        public void ExecuteNonQuery(string sql, IEnumerable<KeyValuePair<string,object>> parameter = null)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.BindByName = true;
                foreach (var x in parameter ?? new List<KeyValuePair<string, object>>())
                {
                    var param = command.CreateParameter();
                    param.ParameterName = x.Key;
                    param.Value = x.Value;
                    command.Parameters.Add(param);
                };
                command.ExecuteNonQuery();
            }
        }
    }
}
