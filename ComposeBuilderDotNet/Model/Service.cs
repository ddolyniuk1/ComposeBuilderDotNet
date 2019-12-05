using System;
using System.Collections.Generic;
using ComposeBuilderDotNet.Model.Base;

namespace ComposeBuilderDotNet.Model
{
    [Serializable]
    public class Service : ObjectBase
    {
        public string ContainerName
        {
            get => GetProperty<string>("container_name");
            set => SetProperty("container_name", value);
        }

        public string Image
        {
            get => GetProperty<string>("image");
            set => SetProperty("image", value);
        }

        public List<string> Networks
        {
            get => GetProperty<List<string>>("networks");
            set => SetProperty("networks", value);
        }

        public List<string> Environment
        {
            get => GetProperty<List<string>>("environment");
            set => SetProperty("environment", value);
        }

        public List<string> Volumes
        {
            get => GetProperty<List<string>>("volumes");
            set => SetProperty("volumes", value);
        }

        public List<string> Ports
        {
            get => GetProperty<List<string>>("ports");
            set => SetProperty("ports", value);
        }

        public List<string> Expose
        {
            get => GetProperty<List<string>>("expose");
            set => SetProperty("expose", value);
        }

        public List<string> Secrets
        {
            get => GetProperty<List<string>>("secrets");
            set => SetProperty("secrets", value);
        }
    }
}