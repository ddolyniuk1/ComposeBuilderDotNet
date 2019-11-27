using System;
using System.Collections.Generic;
using ComposeBuilderDotNet.Interfaces;
using YamlDotNet.Serialization;

namespace ComposeBuilderDotNet.Model.Base
{
    [Serializable]
    public class ObjectBase : Dictionary<string, object>, IObject
    {
        [YamlIgnore] public string Name { get; set; }

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
    }
}