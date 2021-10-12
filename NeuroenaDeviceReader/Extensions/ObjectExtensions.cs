using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NeuroenaDeviceReader.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetPropertiesNames(this object obj, string delimeter)
        {
            return GetPropertyRecord(obj, delimeter, prop => prop.Name);
        }

        public static string GetPropertiesValues(this object obj, string delimeter)
        {
            return GetPropertyRecord(obj, delimeter, prop => prop.GetValue(obj).ToString());
        }

        private static string GetPropertyRecord(object obj, string delimeter, Func<PropertyInfo, string> propertyChoice)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var type = obj.GetType();
            var properties = type.GetProperties();

            properties.Select(prop => stringBuilder.Append(propertyChoice(prop) + delimeter)).ToArray();

            return stringBuilder.ToString();
        }
    }
}
