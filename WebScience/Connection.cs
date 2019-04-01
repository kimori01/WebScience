using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebScience
{
    public static class Connection
    {
        public static readonly IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ModelScience"].ConnectionString);

    }
}