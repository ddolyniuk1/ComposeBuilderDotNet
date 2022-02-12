using DockerComposeBuilder.Model.Infrastructure;
using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace DockerComposeBuilder.Emitters;

public class YamlValueCollectionConverter : IYamlTypeConverter
{
    public bool Accepts(Type type) => typeof(IValueCollection).IsAssignableFrom(type);

    public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        if (value is IValueCollection valueCollection)
        {
            emitter.Emit(new SequenceStart(AnchorName.Empty, TagName.Empty, false, SequenceStyle.Block));

            foreach (var item in valueCollection)
            {
                if (item is IKeyValue keyValue)
                {
                    emitter.Emit(new Scalar(AnchorName.Empty, TagName.Empty, $"{keyValue.Key}={keyValue.Value}", ScalarStyle.DoubleQuoted, true, false));
                }
                else if (item is IKey key)
                {
                    emitter.Emit(new Scalar(AnchorName.Empty, TagName.Empty, key.Key, ScalarStyle.DoubleQuoted, true, false));
                }
            }

            emitter.Emit(new SequenceEnd());
        }
    }
}
