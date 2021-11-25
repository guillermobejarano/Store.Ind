using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Store.Ind.Insfrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FieldTitleAttribute : Attribute
    {
        public FieldTitleAttribute(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        public string Name { get; private set; }
    }

    public static class FileHelpersTypeExtensions
    {
        public static IEnumerable<string> GetFieldTitles(this Type type)
        {
            var fields = from field in type.GetProperties(
                BindingFlags.GetField |
                BindingFlags.GetProperty |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance)
                         where field.IsFileHelpersField()
                         select field;

            return from field in fields
                   let attrs = field.GetCustomAttributes(true)
                   let order = attrs.OfType<FieldOrderAttribute>().Single().GetOrder()
                   let title = attrs.OfType<FieldTitleAttribute>().Single().Name
                   orderby order
                   select title;
        }

        public static string GetCsvHeader(this Type type, string delimiter)
        {
            return String.Join(delimiter, type.GetFieldTitles());
        }

        static bool IsFileHelpersField(this PropertyInfo field)
        {
            return field.GetCustomAttributes(true)
                .OfType<FieldOrderAttribute>()
                .Any();
        }

        static int GetOrder(this FieldOrderAttribute attribute)
        {
            var pi = typeof(FieldOrderAttribute).GetProperty("Order");

            return (int)pi.GetValue(attribute, null);
        }
    }
}
