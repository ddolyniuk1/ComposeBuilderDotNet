using System.Collections.Generic;

namespace Aviationexam.DockerComposeBuilder.Builders.Base
{
    public abstract class BaseBuilder<TBuilderType, TObjectType>
        where TObjectType : class, new()
        where TBuilderType : BaseBuilder<TBuilderType, TObjectType>
    {
        protected TObjectType WorkingObject { get; set; } = new TObjectType();

        protected TBuilderType AddToDictionary<T>(IDictionary<string, T> original, IDictionary<string, T> source)
        {
            foreach (var item in source)
            {
                original[item.Key] = item.Value;
            }

            return (TBuilderType) this;
        }

        public TObjectType Build()
        {
            return WorkingObject;
        }
    }
}
