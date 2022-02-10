using System;
using ComposeBuilderDotNet.Model;
using ComposeBuilderDotNet.Model.Base;

namespace ComposeBuilderDotNet.Builders.Base
{
    public abstract class BuilderBase<TBuilderType, TObjectType>
        where TObjectType : ObjectBase, new()
        where TBuilderType : BuilderBase<TBuilderType, TObjectType>
    {
        protected TObjectType WorkingObject { get; set; } = new TObjectType();


        public TBuilderType WithName(string name)
        {
            WorkingObject.Name = name;
            return this as TBuilderType;
        }

        public TBuilderType WithProperty(string property, object value)
        {
            WorkingObject[property] = value;
            return this as TBuilderType;
        }

        public TBuilderType WithMap(string mapName, Action<MapBuilder> mapConfigureExpression)
        {
            var mb = new MapBuilder().WithName(mapName);
            mapConfigureExpression(mb);
            WorkingObject[mapName] = mb.Build();
            return this as TBuilderType;
        }

        public TBuilderType WithMap(Map map)
        {
            WorkingObject[map.Name] = map;
            return this as TBuilderType;
        }

        public TObjectType Build()
        {
            return WorkingObject;
        }
    }
}
