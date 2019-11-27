using System.Collections.Generic;
using ComposeBuilderDotNet.Builders.Base;
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

        public ServiceBuilder WithEnvironment(params string[] environmentMappings)
        {
            if (WorkingObject.Environment == null)
            {
                WorkingObject.Environment = new List<string>();
            }

            WorkingObject.Environment.AddRange(environmentMappings);
            return this;
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

        public SwarmServiceBuilder WithSwarm()
        {
            return new SwarmServiceBuilder {WorkingObject = WorkingObject};
        }
    }
}