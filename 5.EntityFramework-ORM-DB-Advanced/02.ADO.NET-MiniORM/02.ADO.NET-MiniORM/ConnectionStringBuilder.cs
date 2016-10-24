using System;
using System.Data.SqlClient;

namespace _02.ADO.NET_MiniORM
{
    class ConnectionStringBuilder
    {
        private SqlConnectionStringBuilder builder;

        private string connectionString;

        public ConnectionStringBuilder(string databaseName)
        {
            this.builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = "(local)";
            builder["Integrated Security"] = true;
            builder["Connect Timeout"] = 1000;
            builder["Trusted_Connection"] = true;
            builder["Initial Catalog"] = databaseName;
            this.connectionString = builder.ToString();
        }

        public string ConnectionString { get { return this.connectionString; } }
    }
}
