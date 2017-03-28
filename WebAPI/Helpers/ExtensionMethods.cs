using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;

namespace Samples.WebAPI.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetEmail(this IIdentity identity)
        {
            var emailClaim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Email);
            return emailClaim != null ? emailClaim.Value : string.Empty;
        }

        /// <summary>
        /// This extension loops through all string, int, short, long, decimal properties and see if there is even one Property has value (non-default).
        /// </summary>
        /// <param name="myObject">An object with properties</param>
        /// <returns>True - Even if there is  one Property has value (non-default) </returns>
        public static bool IsAnyPropertySet(this object myObject)
        {
            bool isAnyPropertySet = false;
            var props = myObject.GetType().GetProperties();

            //If any string is set
            isAnyPropertySet = props.Where(pi => pi.GetValue(myObject) is string).Select(pi => (string)pi.GetValue(myObject)).Any(value => !String.IsNullOrWhiteSpace(value));
            if (isAnyPropertySet) { return isAnyPropertySet; }

            //If int string is set
            isAnyPropertySet = props.Where(pi => pi.GetValue(myObject) is int).Select(pi => (int)pi.GetValue(myObject)).Any(value => value > 0);
            if (isAnyPropertySet) { return isAnyPropertySet; }

            //If any short is set
            isAnyPropertySet = props.Where(pi => pi.GetValue(myObject) is short).Select(pi => (short)pi.GetValue(myObject)).Any(value => value > 0);
            if (isAnyPropertySet) { return isAnyPropertySet; }

            //If any long is set
            isAnyPropertySet = props.Where(pi => pi.GetValue(myObject) is long).Select(pi => (long)pi.GetValue(myObject)).Any(value => value > 0);
            if (isAnyPropertySet) { return isAnyPropertySet; }

            //If any decimal is set
            isAnyPropertySet = props.Where(pi => pi.GetValue(myObject) is decimal).Select(pi => (decimal)pi.GetValue(myObject)).Any(value => value > 0);
            if (isAnyPropertySet) { return isAnyPropertySet; }

            return isAnyPropertySet;
        }

        /// <summary>
        /// This extension method takes a string and searches for it in the source string. An optional Value [ignoreNullOrEmpty: true] can be specified to ignore Null or Empty Strings
        /// </summary>
        /// <param Name="source">Source of the string</param>
        /// <param Name="stringToFind">String to Find in the Source</param>
        /// <param Name="ignoreNullOrEmpty">A bool Value to indicate whether to ignore Null or Empty values</param>
        /// <returns>Returns true if found</returns>
        public static bool CustomCompare(this string source, string stringToFind, bool ignoreNullOrEmpty = false)
        {
            if (ignoreNullOrEmpty && string.IsNullOrEmpty(stringToFind)) { return true; }
            return string.IsNullOrEmpty(source) ? false : source.IndexOf(stringToFind, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// This extension method matches the exact string ignoring the casing.
        /// </summary>
        /// <param Name="source">Source of the string</param>
        /// <param Name="stringToFind">String to Match in the Source</param>
        /// <param Name="ignoreNullOrEmpty">A bool Value to indicate whether to ignore Null or Empty values</param>
        /// <returns>Returns true if matched</returns>
        public static bool ExactMatch(this string source, string stringToFind, bool ignoreNullOrEmpty = false)
        {
            if (ignoreNullOrEmpty && string.IsNullOrEmpty(stringToFind)) { return true; }
            return string.IsNullOrEmpty(source) ? false : String.CompareOrdinal(source, stringToFind) == 0;
        }
        /// <summary>
        /// This extension method appends the / character at the end of URL.
        /// </summary>
        /// <param Name="source">Source of the string</param>
        /// <returns>A String URL properly formatted</returns>
        public static string FormatURL(this string source)
        {
            if (String.IsNullOrWhiteSpace(source)) { return source; }
            if (source.IndexOf("/", StringComparison.OrdinalIgnoreCase) < 0) { return source; }

            var lastIndexOf = source.LastIndexOf("/");
            var length = source.Length;

            if (lastIndexOf + 1 == length)
            { return source; }
            else { return source + "/"; }
        }

        public static string CleanSharePointValues(this string source)
        {
            if (source.Contains(";#")) { source = source.Substring(source.IndexOf(";#") + 2); }
            return source;
        }

        /// <summary>
        /// This extension method takes a string and returns a substring after the last "\" seperator character
        /// </summary>
        /// <param Name="source">Source of the string</param>
        /// <param Name="separator">An optional separator. Default is back slash character "\"</param>
        /// <returns></returns>
        public static string GetLastPart(this string source, char separator = ' ')
        {
            if (string.IsNullOrEmpty(source))
            { return String.Empty; }

            separator = separator == ' ' ? '\\' : separator;

            if (source.IndexOf(separator) < 0)
            { return source; }

            return source.Substring(source.LastIndexOf(separator) + 1);
        }


        /// <summary>
        /// This extension method takes a string and returns a substring until the first "\" seperator character
        /// </summary>
        /// <param Name="source">Source of the string</param>
        /// <param Name="separator">An optional separator. Default is back slash character "\"</param>
        /// <returns></returns>
        public static string GetFirstPart(this string source, char separator = ' ')
        {
            if (string.IsNullOrEmpty(source))
            { return String.Empty; }

            separator = separator == ' ' ? '\\' : separator;

            if (source.IndexOf(separator) < 0)
            { return source; }

            return source.Substring(0, source.IndexOf(separator) + 1);
        }

        /// <summary>
        /// This extension method checks whether the pass Type matches the object Type. Usuage ex [SomeStringArray.GetType().IsArrayOf<string>()]
        /// </summary>
        /// <typeparam Name="T"></typeparam>
        /// <param Name="Type"></param>
        /// <returns>Returns true or false Value indicating the match</returns>
        public static bool IsArrayOf<T>(this Type type)
        {
            return type == typeof(T[]);
        }

        /// <summary>
        /// This extension method takes an object and initializes empty (null) arrays to their default types
        /// </summary>
        /// <param Name="myObject">Any kind of Object</param>
        public static void InitializeEmptyArrays(this object myObject)
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


        /// <summary>
        /// This extension method takes an object and converts all String Properties to Upper Case
        /// </summary>
        /// <param Name="myObject">Any kind of Object</param>
        public static object ConvertToUpperCase<T>(this T myObject)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType == typeof(string))
                {
                    var value = (string)prop.GetValue(myObject);
                    prop.SetValue(myObject, value.Trim().ToUpper());
                }
            }
            return myObject;
        }

        /// <summary>
        /// This extension method takes an object and converts all String Properties to Upper Case
        /// </summary>
        /// <param Name="myObject">Any kind of Object</param>
        public static T CleanString<T>(this T myObject)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType == typeof(string))
                {
                    var value = (string)prop.GetValue(myObject);
                    prop.SetValue(myObject, value.Trim());
                }
            }
            return myObject;
        }

    }
}