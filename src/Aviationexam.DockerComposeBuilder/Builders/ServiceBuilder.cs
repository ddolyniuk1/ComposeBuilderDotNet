using Aviationexam.DockerComposeBuilder.Builders.Base;
using Aviationexam.DockerComposeBuilder.Builders.Services;
using Aviationexam.DockerComposeBuilder.Enums;
using Aviationexam.DockerComposeBuilder.Model;
using Aviationexam.DockerComposeBuilder.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aviationexam.DockerComposeBuilder.Builders
{
    public class ServiceBuilder : BaseBuilder<ServiceBuilder, Service>
    {
        protected BuildBuilder? _buildBuilder;

        internal ServiceBuilder()
        {
        }

        public ServiceBuilder WithName(string name)
        {
            WorkingObject.Name = name;

            return this;
        }

        public ServiceBuilder WithContainerName(string containerName)
        {
            WorkingObject.ContainerName = containerName;
            return this;
        }

        public ServiceBuilder WithDependencies(params string[] services)
        {
            WorkingObject.DependsOn ??= new List<string>();

            var dependsOnList = WorkingObject.DependsOn as List<string>;

            dependsOnList?.AddRange(services);
            return this;
        }

        public ServiceBuilder WithDependencies(params Service[] services)
        {
            return WithDependencies(services.Select(t => t.Name).ToArray());
        }

        public ServiceBuilder WithHealthCheck(Action<HealthCheck> healthCheck)
        {
            WorkingObject.HealthCheck ??= new HealthCheck();

            healthCheck(WorkingObject.HealthCheck);

            return this;
        }

        public ServiceBuilder WithEnvironment(IDictionary<string, string?> environmentMappings)
        {
            WorkingObject.Environment ??= new Dictionary<string, string>();

            return AddToDictionary(WorkingObject.Environment, environmentMappings);
        }

        public ServiceBuilder WithEnvironment(Action<IDictionary<string, string?>> environmentExpression)
        {
            WorkingObject.Environment ??= new Dictionary<string, string?>();

            environmentExpression(WorkingObject.Environment);

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

        public ServiceBuilder WithExposed(params object[] exposed)
        {
            if (WorkingObject.Expose == null)
            {
                WorkingObject.Expose = new List<string>();
            }

            WorkingObject.Expose.AddRange(exposed.Select(t => t.ToString()));
            return this;
        }

        public ServiceBuilder WithHostname(string hostname)
        {
            WorkingObject.Hostname = hostname;
            return this;
        }

        public ServiceBuilder WithLabels(IDictionary<string, string> labels)
        {
            WorkingObject.Labels ??= new Dictionary<string, string>();

            return AddToDictionary(WorkingObject.Labels, labels);
        }

        public ServiceBuilder WithLabels(Action<IDictionary<string, string>> environmentExpression)
        {
            WorkingObject.Labels ??= new Dictionary<string, string>();

            environmentExpression(WorkingObject.Labels);

            return this;
        }

        public ServiceBuilder WithBuild(Action<BuildBuilder> build)
        {
            _buildBuilder ??= new BuildBuilder();

            build(_buildBuilder);

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

        public ServiceBuilder WithPortMappings(params Port[] mappings)
        {
            if (WorkingObject.Ports == null)
            {
                WorkingObject.Ports = new List<Port>();
            }

            WorkingObject.Ports.AddRange(mappings);
            return this;
        }

        public ServiceBuilder WithExtraHosts(params string[] extraHosts)
        {
            if (WorkingObject.ExtraHosts == null)
            {
                WorkingObject.ExtraHosts = new List<string>();
            }

            WorkingObject.ExtraHosts.AddRange(extraHosts);
            return this;
        }

        public ServiceBuilder WithCommands(params string[] commands)
        {
            if (WorkingObject.Commands == null)
            {
                WorkingObject.Commands = new List<string>();
            }

            WorkingObject.Commands.AddRange(commands);
            return this;
        }

        public ServiceBuilder WithRestartPolicy(ERestartMode mode)
        {
            WorkingObject.Restart = mode;
            return this;
        }

        public ServiceBuilder WithSecrets(params string[] secrets)
        {
            if (WorkingObject.Secrets == null)
            {
                WorkingObject.Secrets = new List<string>();
            }

            WorkingObject.Secrets.AddRange(secrets);
            return this;
        }

        public ServiceBuilder WithSecrets(params Secret[] secrets)
        {
            return WithSecrets(secrets.Select(t => t.Name).ToArray());
        }

        public SwarmServiceBuilder WithSwarm()
        {
            return new SwarmServiceBuilder { WorkingObject = WorkingObject };
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

        public override Service Build()
        {
            if (_buildBuilder != null)
            {
                WorkingObject.Build = _buildBuilder.Build();
            }

            return base.Build();
        }
    }
}
