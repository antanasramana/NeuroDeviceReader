using System;
using System.Collections.Generic;
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

        private static string GetPropertyRecord<T>(T obj, string delimeter, Func<PropertyInfo, string> funcToExecute)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                stringBuilder.Append(funcToExecute(property));
                stringBuilder.Append(delimeter);
            }

            return stringBuilder.ToString();
        }
    }
}
