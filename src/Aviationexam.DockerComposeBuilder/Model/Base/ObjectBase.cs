using Aviationexam.DockerComposeBuilder.Interfaces;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Aviationexam.DockerComposeBuilder.Model.Base
{
    [Serializable]
    public class ObjectBase : Dictionary<string, object>, IObject
    {
        [YamlIgnore]
        public string Name { get; set; }

        public T SetProperty<T>(string property, T value)
        {
            if (value is string strValue)
            {
                this[property] = strValue;
                return value;
            }

            this[property] = value;
            return value;
        }

        public bool TryGetProperty<T>(string property, out T result) where T : class
        {
            if (ContainsKey(property))
            {
                result = this[property] as T;
                return true;
            }

            result = null;
            return false;
        }

        public T GetProperty<T>(string property) where T : class
        {
            TryGetProperty<T>(property, out var result);
            return result;
        }

        public int? GetIntProperty(string property)
        {
            if (
                TryGetProperty<string>(property, out var stringValue)
                && int.TryParse(stringValue, out var intValue)
            )
            {
                return intValue;
            }

            return null;
        }

        public TEnum? GetEnumProperty<TEnum>(string property) where TEnum : struct, Enum
        {
            if (
                TryGetProperty<string>(property, out var stringValue)
            )
            {
                if (Enum.TryParse<TEnum>(stringValue, out var enumValue))
                {
                    return enumValue;
                }
            }

            return null;
        }
    }
}
