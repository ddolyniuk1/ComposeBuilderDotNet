using Aviationexam.DockerComposeBuilder.Builders.Base;
using Aviationexam.DockerComposeBuilder.Model;
using System;
using System.Collections.Generic;

namespace Aviationexam.DockerComposeBuilder.Builders
{
    public class ComposeBuilder : BaseBuilder<ComposeBuilder, Compose>
    {
        public ComposeBuilder WithVersion(string version)
        {
            WorkingObject.Version = version;
            return this;
        }

        /// <summary>
        ///     Add services to the Compose object
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public ComposeBuilder WithServices(params Service[] services)
        {
            if (WorkingObject.Services == null)
            {
                WorkingObject.Services = new Dictionary<string, Service>();
            }

            foreach (var service in services)
            {
                if (WorkingObject.Services.ContainsKey(service.Name))
                {
                    throw new Exception("Service name already added to services, please pick a unique one!");
                }

                WorkingObject.Services.Add(service.Name, service);
            }

            return this;
        }

        /// <summary>
        ///     Add networks to the compose object
        /// </summary>
        /// <param name="networks"></param>
        /// <returns></returns>
        public ComposeBuilder WithNetworks(params Network[] networks)
        {
            if (WorkingObject.Networks == null)
            {
                WorkingObject.Networks = new Dictionary<string, Network>();
            }

            foreach (var network in networks)
            {
                if (WorkingObject.Networks.ContainsKey(network.Name))
                {
                    throw new Exception("Network name already added to networks, please pick a unique one!");
                }

                WorkingObject.Networks.Add(network.Name, network);
            }

            return this;
        }

        /// <summary>
        ///     Add volumes to the compose object
        /// </summary>
        /// <param name="volumes"></param>
        /// <returns></returns>
        public ComposeBuilder WithVolumes(params Volume[] volumes)
        {
            if (WorkingObject.Networks == null)
            {
                WorkingObject.Volumes = new Dictionary<string, Volume>();
            }

            foreach (var volume in volumes)
            {
                if (WorkingObject.Volumes.ContainsKey(volume.Name))
                {
                    throw new Exception("Volume name already added to volumes, please pick a unique one!");
                }

                WorkingObject.Volumes.Add(volume.Name, volume);
            }

            return this;
        }

        /// <summary>
        ///     Add secrets to the compose object
        /// </summary>
        /// <param name="secrets"></param>
        /// <returns></returns>
        public ComposeBuilder WithSecrets(params Secret[] secrets)
        {
            if (WorkingObject.Secrets == null)
            {
                WorkingObject.Secrets = new Dictionary<string, Secret>();
            }

            foreach (var secret in secrets)
            {
                if (WorkingObject.Secrets.ContainsKey(secret.Name))
                {
                    throw new Exception("Secret name already added to secrets, please pick a unique one!");
                }

                WorkingObject.Secrets.Add(secret.Name, secret);
            }

            return this;
        }
    }
}
