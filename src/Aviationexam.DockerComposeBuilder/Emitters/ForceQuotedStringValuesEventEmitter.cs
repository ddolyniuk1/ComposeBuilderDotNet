using System;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.EventEmitters;

namespace Aviationexam.DockerComposeBuilder.Emitters
{
    public class ForceQuotedStringValuesEventEmitter : ChainedEventEmitter
    {
        private readonly Stack<EmitterState> _state = new Stack<EmitterState>();

        public ForceQuotedStringValuesEventEmitter(IEventEmitter nextEmitter)
            : base(nextEmitter)
        {
            _state.Push(new EmitterState(EmitterState.EventType.Root));
        }

        public override void Emit(ScalarEventInfo eventInfo, IEmitter emitter)
        {
            var item = _state.Peek();
            item.Move();

            if (item.ShouldApply() && eventInfo.Source.Type == typeof(string))
            {
                eventInfo = new ScalarEventInfo(eventInfo.Source)
                {
                    Style = ScalarStyle.DoubleQuoted,
                };
            }

            base.Emit(eventInfo, emitter);
        }

        public override void Emit(MappingStartEventInfo eventInfo, IEmitter emitter)
        {
            _state.Peek().Move();
            _state.Push(new EmitterState(EmitterState.EventType.Mapping));
            base.Emit(eventInfo, emitter);
        }

        public override void Emit(MappingEndEventInfo eventInfo, IEmitter emitter)
        {
            var item = _state.Pop();
            if (item.Type != EmitterState.EventType.Mapping)
            {
                throw new Exception();
            }

            base.Emit(eventInfo, emitter);
        }

        public override void Emit(SequenceStartEventInfo eventInfo, IEmitter emitter)
        {
            _state.Peek().Move();
            _state.Push(new EmitterState(EmitterState.EventType.Sequence));
            base.Emit(eventInfo, emitter);
        }

        public override void Emit(SequenceEndEventInfo eventInfo, IEmitter emitter)
        {
            var item = _state.Pop();
            if (item.Type != EmitterState.EventType.Sequence)
            {
                throw new Exception();
            }

            base.Emit(eventInfo, emitter);
        }

        private class EmitterState
        {
            public EventType Type { get; }

            private int _currentIndex;

            public EmitterState(EventType eventType)
            {
                Type = eventType;
            }

            public void Move()
            {
                _currentIndex++;
            }

            public bool ShouldApply() => Type switch
            {
                EventType.Mapping => _currentIndex % 2 == 0,
                EventType.Sequence => true,
                _ => false,
            };

            public enum EventType : byte
            {
                Root,
                Mapping,
                Sequence,
            }
        }
    }
}
