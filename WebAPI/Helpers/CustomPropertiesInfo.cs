using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.WebAPI.Helpers
{
    public class CustomPropertiesInfo
    {

        public static IEnumerable<object> GetStringProperties(object myObject)
        {
            var stringPropertyNamesAndValues = myObject.GetType().GetProperties()
                                                    .Where(pi => pi.PropertyType == typeof(string) && pi.GetGetMethod() != null)
                                                    .Select(pi => new { Name = pi.Name, Value = pi.GetValue(myObject, null) });

            return stringPropertyNamesAndValues;
        }

        /// <summary>
        /// This function loops through all String properties of an object and checks if at least one property is set, then returns true. Otherwise false
        /// </summary>
        /// <param Name="myObject">An Object whose properties to search</param>
        /// <returns></returns>
        public static bool IsAnyStringPropertySet(object myObject)
        {
            bool isAnyPropertySet = false;

            var stringPropertyNamesAndValues = myObject.GetType().GetProperties().Where(p => p.CanRead && p.PropertyType == typeof(String))
                                              .ToDictionary(p => p.Name, p => (String)p.GetValue(myObject, null));

            foreach (var item in stringPropertyNamesAndValues)
            {
                if (item.Value != null && !item.Value.Trim().Equals("")) { isAnyPropertySet = true; break; }
            }
            return isAnyPropertySet;
        }

        public static void InitializeEmptyArrays(object myObject)
        {
            var allArrays = myObject.GetType().GetProperties().Where(p => p.CanRead && p.PropertyType.IsArray);

            foreach (var prop in allArrays)
            {
                var value = (Array)prop.GetValue(myObject);

                if (value == null || value.Length < 1)
                {
                    if (prop.PropertyType == typeof(Int16[])) { prop.SetValue(myObject, Arrays<short>.Empty); }
                    if (prop.PropertyType == typeof(Int32[])) { prop.SetValue(myObject, Arrays<int>.Empty); }
                    if (prop.PropertyType == typeof(Int64[])) { prop.SetValue(myObject, Arrays<long>.Empty); }
                    if (prop.PropertyType == typeof(string[])) { prop.SetValue(myObject, Arrays<string>.Empty); }
                }
            }//End of Foreach
        }
    }
}