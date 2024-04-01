﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace NCHS_CRM.DataConnection
{
    public class SqlServerHelper
    {
        private readonly string _connectionString;
        public SqlServerHelper(string connectionString)
        {
            if (ConfigurationManager.ConnectionStrings[connectionString] == null)
                throw new Exception("'" + connectionString + "' is not found in config");
            _connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public T SqlSpExecute<T>(string spName, Func<SqlCommand, T> commandInjector)
        {
            T ret = default(T);
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (commandInjector != null)
                        ret = commandInjector(cmd);
                }
            }
            return ret;
        }
    }

}
