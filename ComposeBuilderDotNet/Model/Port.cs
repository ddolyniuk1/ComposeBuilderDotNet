using ComposeBuilderDotNet.Model.Base;
using System;

namespace ComposeBuilderDotNet.Model
{
    [Serializable]
    public class Port : ObjectBase
    {
        public int? Target
        {
            get => GetIntProperty("target");
            set => SetProperty("target", value);
        }

        public int? Published
        {
            get => GetIntProperty("published");
            set => SetProperty("published", value);
        }

        public string Protocol
        {
            get => GetProperty<string>("protocol");
            set => SetProperty("protocol", value);
        }

        public string Mode
        {
            get => GetProperty<string>("mode");
            set => SetProperty("mode", value);
        }
    }
}
