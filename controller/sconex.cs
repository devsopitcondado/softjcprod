using System.Configuration;
using System.Data.SqlClient;


namespace Softjc.controller
{
    public class sconex
    {
        public SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Jcdb"].ConnectionString);
    }
}