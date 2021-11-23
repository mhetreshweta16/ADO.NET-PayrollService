using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOProject
{
    class PayrollServicConnection
    {
        public string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlConnection sqlConnection = new SqlConnection();
    }
}
