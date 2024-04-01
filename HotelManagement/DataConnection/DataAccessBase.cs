using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCHS_CRM.DataConnection
{
    public class DataAccessBase
    {
        public const string connectionString = "NCHSConnection";
        private SqlServerHelper _Data = new SqlServerHelper(connectionString);

        public SqlServerHelper Data { get { return _Data; } }
    }
}