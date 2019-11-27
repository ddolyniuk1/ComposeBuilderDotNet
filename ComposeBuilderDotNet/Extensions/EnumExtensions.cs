using System;
using System.ComponentModel;

namespace ComposeBuilderDotNet.Extensions
{
    public static class EnumString
    {
        public static string GetDescription(this Enum value)
        {
            var output = value.ToString();
            var type = value.GetType();
            var fi = type.GetField(value.ToString());
            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attrs && attrs.Length > 0)
            {
                output = attrs[0].Description;
            }
            return output;
        }
    }
}
