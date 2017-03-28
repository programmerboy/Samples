using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Samples.WebAPI.Helpers
{
    public class SPHelper
    {
        public static int ReturnedValue;
        public static string ReturnedValueStr;
        public static string Error;

        public static DataTable GetDataTable(String spName, List<QueryParameter> listOfParameters = null)
        {
            var _connectionString = String.Empty; // ConfigurationManager.ConnectionStrings["MyCon"].ToString();

            try
            {
                Error = String.Empty;

                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (listOfParameters != null) listOfParameters.ForEach(item => cmd.Parameters.Add(item.Name, item.Type, item.Value, ParameterDirection.Input));

                    cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex);
                return new DataTable();
            }
        }

        public static bool RunSP(String spName, List<QueryParameter> listOfParameters)
        {
            var _connectionString = String.Empty;
            try
            {
                Error = String.Empty;

                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (listOfParameters != null) listOfParameters.ForEach(item => cmd.Parameters.Add(item.Name, item.Type).Value = item.Value);

                    cmd.ExecuteNonQuery();

                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                        con.Dispose();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex);
                return false;
            }
        }

        public static int FunctionSPHelper(String spName, List<QueryParameter> listOfParameters, string returnValue = "ret_val")
        {
            var _connectionString = String.Empty;
            try
            {
                Error = String.Empty;
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    //This Parameters returns the Value of the function
                    OracleParameter funcValue = new OracleParameter("Return_Value", OracleDbType.Int16, ParameterDirection.ReturnValue);

                    //This Ouput Parameters returns the Value assigned to this Parameter in the Function
                    OracleParameter outParam = new OracleParameter(returnValue, OracleDbType.Int32, ParameterDirection.ReturnValue);

                    //funcValue parameter should be the first parameter in the _existingRanges of Parameters
                    cmd.Parameters.Add(funcValue);
                    if (listOfParameters != null) listOfParameters.ForEach(item => cmd.Parameters.Add(item.Name, item.Type, item.Value, ParameterDirection.Input));
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();
                    ReturnedValue = Convert.ToInt32(outParam.Value.ToString());
                    return Convert.ToInt32(funcValue.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex);
                Error = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// Helper function which takes 3 arguments and returns a String value back
        /// </summary>
        /// <param name="spName">Name of the Function</param>
        /// <param name="listOfParameters">List of Parameters</param>
        /// <param name="_returnValueParamName">Name of the return value parameter</param>
        /// <returns>String containing return value from the Function</returns>
        public static string FunctionSPHelperStr(String spName, List<QueryParameter> listOfParameters, string _returnValueParamName = "ret_val")
        {
            var _connectionString = String.Empty;

            try
            {
                Error = String.Empty;
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter funcValue = new OracleParameter("Return_Value", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    funcValue.Size = 200; // Need to define size otherwise you will receive ORA-06502: PL/SQL: numeric or value error
                    OracleParameter outParam = new OracleParameter(_returnValueParamName, OracleDbType.Varchar2, ParameterDirection.Output);
                    outParam.Size = 200; // Need to define size otherwise you will receive ORA-06502: PL/SQL: numeric or value error

                    cmd.Parameters.Add(funcValue);
                    if (listOfParameters != null) listOfParameters.ForEach(item => cmd.Parameters.Add(item.Name, item.Type, item.Value, ParameterDirection.Input));
                    cmd.Parameters.Add(outParam);
                    cmd.ExecuteNonQuery();
                    ReturnedValueStr = outParam.Value.ToString();
                    return funcValue.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex);
                return null;
            }
        }
    }

    public class QueryParameter
    {
        public string Name { get; set; }
        public OracleDbType Type { get; set; }
        public object Value { get; set; }
    }
}