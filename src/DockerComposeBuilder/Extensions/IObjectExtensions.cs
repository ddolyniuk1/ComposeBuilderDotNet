using DockerComposeBuilder.Emitters;
using DockerComposeBuilder.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DockerComposeBuilder.Extensions
{
    public static class ComposeExtensions
    {
        public static string Serialize(this Compose serializable)
        {
            var serializer = new SerializerBuilder()
                .WithTypeConverter(new YamlValueCollectionConverter())
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .WithEventEmitter(nextEmitter => new FlowStyleStringSequences(nextEmitter))
                .WithEventEmitter(nextEmitter => new FlowStringEnumConverter(nextEmitter))
                .WithEventEmitter(nextEmitter => new ForceQuotedStringValuesEventEmitter(nextEmitter))
                .WithEmissionPhaseObjectGraphVisitor(args => new YamlIEnumerableSkipEmptyObjectGraphVisitor(args.InnerVisitor))
                .Build();

            return serializer.Serialize(serializable);
        }
    }
}
