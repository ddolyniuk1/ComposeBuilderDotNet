using ComposeBuilderDotNet.Enums;
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

        public HealthCheck HealthCheck
        {
            get => GetProperty<HealthCheck>("healthcheck");
            set => SetProperty("healthcheck", value);
        }

        public string Hostname
        {
            get => GetProperty<string>("hostname");
            set => SetProperty("hostname", value);
        }

        public List<string> Networks
        {
            get => GetProperty<List<string>>("networks");
            set => SetProperty("networks", value);
        }

        public IDictionary<string, string> Labels
        {
            get => GetProperty<IDictionary<string, string>>("labels");
            set => SetProperty("labels", value);
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

        public List<Port> Ports
        {
            get => GetProperty<List<Port>>("ports");
            set => SetProperty("ports", value);
        }

        public List<string> ExtraHosts
        {
            get => GetProperty<List<string>>("extra_hosts");
            set => SetProperty("extra_hosts", value);
        }

        public List<string> Commands
        {
            get => GetProperty<List<string>>("command");
            set => SetProperty("command", value);
        }

        public ERestartMode? Restart
        {
            get => GetEnumProperty<ERestartMode>("restart");
            set => SetProperty("restart", value);
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
