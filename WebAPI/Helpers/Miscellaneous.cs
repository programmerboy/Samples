using System;
using System.Data;
using System.Web;
using Newtonsoft.Json;

namespace Samples.WebAPI.Helpers
{
    public class Miscellaneous
    {
        public static string GetIPAddress(HttpRequest req)
        {
            try {
                string ipAddress = req.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipAddress)) {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0) { return addresses[0]; }
                }
                return req.ServerVariables["REMOTE_ADDR"];
            }
            catch (Exception) {
                return String.Empty;
            }
        }//End of GetIPAddress

        public static object ConvertDataTableToJSON(DataTable _dt)
        {
            string _jsonString = String.Empty;
            var settings = new JsonSerializerSettings();
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            _jsonString = JsonConvert.SerializeObject(_dt, settings); //This method converts the data table into JSON string
            var _jsonObject = JsonConvert.DeserializeObject(_jsonString); //This method converts the converted string into JSON object
            return _jsonObject;
        }
    }
}