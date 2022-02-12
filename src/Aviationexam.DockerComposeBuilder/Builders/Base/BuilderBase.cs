using Aviationexam.DockerComposeBuilder.Model;
using Aviationexam.DockerComposeBuilder.Model.Base;
using System;

namespace Aviationexam.DockerComposeBuilder.Builders.Base
{
    public abstract class BuilderBase<TBuilderType, TObjectType>
        where TObjectType : ObjectBase, new()
        where TBuilderType : BuilderBase<TBuilderType, TObjectType>
    {
        protected TObjectType WorkingObject { get; set; } = new();


        public TBuilderType WithName(string name)
        {
            WorkingObject.Name = name;
            return (TBuilderType) this;
        }

        public TBuilderType WithProperty(string property, object value)
        {
            WorkingObject[property] = value;
            return (TBuilderType) this;
        }

        public TBuilderType WithMap(string mapName, Action<MapBuilder> mapConfigureExpression)
        {
            var mb = new MapBuilder().WithName(mapName);
            mapConfigureExpression(mb);
            WorkingObject[mapName] = mb.Build();
            return (TBuilderType) this;
        }

        public TBuilderType WithMap(Map map)
        {
            WorkingObject[map.Name] = map;
            return (TBuilderType) this;
        }

        public TObjectType Build()
        {
            return WorkingObject;
        }
    }
}
