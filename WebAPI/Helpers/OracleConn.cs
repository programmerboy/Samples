using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Samples.WebAPI.Helpers
{
    public class OracleConn
    {
        OracleConnection con;

        public void Connect()
        {
            var a = new OracleDataSourceEnumerator();
            var test = a.GetDataSources();
            con = new OracleConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyCon"].ToString();
            con.Open();
        }

        public void Close()
        {
            con.Close();
            con.Dispose();
        }
    }
}