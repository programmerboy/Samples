using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC.Helpers
{
    public static class CustomEnumHelper
    {
        public static IEnumerable<SelectListItem> GetItems(
             this Type enumType, int? selectedValue)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw new ArgumentException("OTD (SelectListItem): Type must be an enum");
            }

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>();

            var items = names.Zip(values, (name, value) => new SelectListItem
            {
                Text = GetName(enumType, name),
                Value = value.ToString(),
                Selected = value == selectedValue
            });
            return items;
        }

        public static string DisplayEnumName(
            this Type enumType, int? selectedValue)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw new ArgumentException("OTD (DisplayEnumName): Type must be an enum");
            }

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>();
            int index = 0;
            var result = "";

            foreach (int item in values)
            {
                if (item == selectedValue)
                {
                    result = GetName(enumType, names[index]);
                    index++;
                    break;
                }
                index++;
            }
            return result;
        }

        public static string DisplayEnumName(ModelMetadata modelMetaData, Enum myEnum)
        {
            var result = "";

            //if (EnumHelper.IsValidForEnumHelper(modelMetaData))
            //{
            //    throw new ArgumentException("OTD (Overloaded): Type must be an enum");
            //}

            foreach (SelectListItem item in EnumHelper.GetSelectList(modelMetaData, myEnum))
            {
                if (item.Selected)
                    result = item.Text ?? item.Value;
            }

            // Handle the unexpected case that nothing is selected
            if (String.IsNullOrEmpty(result))
            {
                if (myEnum == null)
                    result = String.Empty;
                else
                    result = myEnum.ToString();
            }

            return result;
        }

        static string GetName(Type enumType, string name)
        {
            var result = name;
            var attribute = enumType
                .GetField(name)
                .GetCustomAttributes(inherit: false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            if (attribute != null)
            {
                result = attribute.GetName();
            }

            return result;
        }
    }
}