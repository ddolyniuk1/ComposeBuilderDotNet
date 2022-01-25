using ComposeBuilderDotNet.Enums;
using ComposeBuilderDotNet.Model.Base;
using System;
using System.Collections.Generic;

namespace ComposeBuilderDotNet.Model
{
    [Serializable]
    public class Deploy : ObjectBase
    {
        public IDictionary<string, string> Labels
        {
            get => GetProperty<IDictionary<string, string>>("labels");
            set => SetProperty("labels", value);
        }

        public EReplicationMode? Mode
        {
            get => GetEnumProperty<EReplicationMode>("mode");
            set => SetProperty("mode", value);
        }

        public int? Replicas
        {
            get => GetIntProperty("replicas");
            set => SetProperty("replicas", value);
        }
    }
}
