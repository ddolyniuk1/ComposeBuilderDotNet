using System;
using System.Collections.Generic;
using System.Linq;
using ComposeBuilderDotNet.Builders.Base;
using ComposeBuilderDotNet.Enums;
using ComposeBuilderDotNet.Extensions;
using ComposeBuilderDotNet.Model;

namespace ComposeBuilderDotNet.Builders
{
    public class ServiceBuilder : BuilderBase<ServiceBuilder, Service>
    {
        internal ServiceBuilder()
        {
        }

        public ServiceBuilder WithPortMapping(params string[] mappings)
        {
            if (WorkingObject.Ports == null)
            {
                WorkingObject.Ports = new List<string>();
            }

            WorkingObject.Ports.AddRange(mappings);
            return this;
        }

        public ServiceBuilder WithExposed(params string[] exposed)
        {
            if (WorkingObject.Expose == null)
            {
                WorkingObject.Expose = new List<string>();
            }

            WorkingObject.Expose.AddRange(exposed);
            return this;
        }

        public ServiceBuilder WithContainerName(string containerName)
        {
            WorkingObject.ContainerName = containerName;
            return this;
        }

        public ServiceBuilder WithImage(string image)
        {
            WorkingObject.Image = image;
            return this;
        }

        public ServiceBuilder WithNetworks(params string[] networks)
        {
            if (WorkingObject.Networks == null)
            {
                WorkingObject.Networks = new List<string>();
            }

            WorkingObject.Networks.AddRange(networks);
            return this;
        }

        public ServiceBuilder WithNetworks(params Network[] networks)
        {
            if (WorkingObject.Networks == null)
            {
                WorkingObject.Networks = new List<string>();
            }

            WorkingObject.Networks.AddRange(networks.Select(t => t.Name));
            return this;
        }

        public ServiceBuilder WithEnvironment(params string[] environmentMappings)
        {
            if (WorkingObject.Environment == null)
            {
                WorkingObject.Environment = new List<string>();
            }

            WorkingObject.Environment.AddRange(environmentMappings);
            return this;
        }

        public ServiceBuilder WithEnvironment(Action<MapBuilder> environmentExpression)
        {
            var mb = new MapBuilder().WithName("environment");
            environmentExpression(mb);
            return WithMap(mb.Build()); 
        }

        public ServiceBuilder WithDependencies(params string[] services)
        {
            if (!WorkingObject.ContainsKey("depends_on"))
            {
                WorkingObject["depends_on"] = new List<string>();
            }
            var dependsOnList = WorkingObject["depends_on"] as List<string>;

            dependsOnList?.AddRange(services);
            return this;
        }

        public ServiceBuilder WithDependencies(params Service[] services)
        {
            return WithDependencies(services.Select(t => t.Name).ToArray());
        }

        public ServiceBuilder WithVolumes(params string[] volumes)
        {
            if (WorkingObject.Volumes == null)
            {
                WorkingObject.Volumes = new List<string>();
            }

            WorkingObject.Volumes.AddRange(volumes);
            return this;
        }

        public ServiceBuilder WithRestartPolicy(ERestartMode mode)
        {
            return WithProperty("restart", mode.GetDescription());
        }

        public SwarmServiceBuilder WithSwarm()
        {
            return new SwarmServiceBuilder {WorkingObject = WorkingObject};
        }
    }
}