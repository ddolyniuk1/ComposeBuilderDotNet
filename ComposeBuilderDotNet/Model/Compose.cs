using System;
using System.Collections.Generic;
using ComposeBuilderDotNet.Model.Base;

namespace ComposeBuilderDotNet.Model
{
    [Serializable]
    public class Compose : ObjectBase
    {
        public string Version
        {
            get => GetProperty<string>("version");
            set => SetProperty("version", value);
        }

        public Dictionary<string, Service> Services
        {
            get => GetProperty<Dictionary<string, Service>>("services");
            set => SetProperty("services", value);
        }

        public Dictionary<string, Network> Networks
        {
            get => GetProperty<Dictionary<string, Network>>("networks");
            set => SetProperty("networks", value);
        }

        public Dictionary<string, Volume> Volumes
        {
            get => GetProperty<Dictionary<string, Volume>>("volumes");
            set => SetProperty("volumes", value);
        }
    }
}