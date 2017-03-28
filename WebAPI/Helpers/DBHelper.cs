using System;
using System.Collections.Generic;
using System.Data;

namespace Samples.WebAPI.Helpers
{
    /*//http://stackoverflow.com/questions/10214155/single-method-which-can-return-the-value-of-a-column-in-a-datarow-and-automatica
     * Got the idea from above link, however this is only good if your Data Types match with each other, for example if your data type
     * is returning Int64 (long) and you are specifying an Int32 Type then it would fail. To cover these scenarios you would have to 
     * manually check as done in the code below
    */
    public static class DBHelper2
    {
        /// <summary>
        /// A Helper method which takes a Generic type and converts it to an actual type after doing validation checks
        /// </summary>
        /// <typeparam name="T">A Generic parameter of any type</typeparam>
        /// <param name="row">Database Row that is returned in the table</param>
        /// <param name="columnName">Name of the column of which value needs to be returned</param>
        /// <returns>Actual Type of Generic T parameter with the appropriate value</returns>
        public static T ConvertValue<T>(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ArgumentException(string.Format("The given DataRow does not contain a field with the name \"{0}\".", columnName));
            }
            else if (row[columnName].Equals(DBNull.Value))
            {
                return default(T);
            }

            var _colDataType = row.Table.Columns[columnName].DataType;
            var _columnValue = row[columnName];
            object _convertedObject;
            Type _specifiedType = typeof(T);

            List<Type> mDataTypes = new List<Type>() { typeof(Int16), typeof(Int32), typeof(Int64), typeof(Decimal), typeof(string) };


            if (_colDataType != _specifiedType)
            {
                //var test = IsNullable<T>();

                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    _specifiedType = Nullable.GetUnderlyingType(_specifiedType);
                }

                if (_specifiedType == typeof(Int32) && mDataTypes.Contains(_colDataType))
                {
                    _convertedObject = Convert.ToInt32(_columnValue);
                }
                else if (_specifiedType == typeof(Int16) && mDataTypes.Contains(_colDataType))
                {
                    _convertedObject = Convert.ToInt16(_columnValue);
                }
                else if (_specifiedType == typeof(Double) && mDataTypes.Contains(_colDataType))
                {
                    _convertedObject = Convert.ToDouble(_columnValue);
                }
                else
                {
                    _convertedObject = Convert.ChangeType(_columnValue, _colDataType);
                }

                return (T)_convertedObject;
            }
            else
            {
                return row.Field<T>(columnName);
            }
        }

        static bool IsNullable<T>()
        {
            Type type = typeof(T);
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }
    }
}