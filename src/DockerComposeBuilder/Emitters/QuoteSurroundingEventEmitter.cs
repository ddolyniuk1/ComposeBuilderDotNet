using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.EventEmitters;

namespace DockerComposeBuilder.Emitters
{
    public class QuoteSurroundingEventEmitter : ChainedEventEmitter
    {
        public QuoteSurroundingEventEmitter(IEventEmitter nextEmitter)
            : base(nextEmitter)
        {
        }

        public override void Emit(ScalarEventInfo eventInfo, IEmitter emitter)
        {
            if (eventInfo.Source.StaticType == typeof(string) || eventInfo.Source.StaticType == typeof(object))
            {
                eventInfo.Style = ScalarStyle.DoubleQuoted;
            }

            base.Emit(eventInfo, emitter);
        }

        public override void Emit(MappingStartEventInfo eventInfo, IEmitter emitter)
        {
            nextEmitter.Emit(eventInfo, emitter);
        }

        public override void Emit(MappingEndEventInfo eventInfo, IEmitter emitter)
        {
            nextEmitter.Emit(eventInfo, emitter);
        }
    }
}
