using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace DockerComposeBuilder.Model
{
    [Serializable]
    public class Compose
    {
        [YamlMember(Alias = "version")]
        public string? Version { get; set; }

        [YamlMember(Alias = "services")]
        public Dictionary<string, Service>? Services { get; set; }

        [YamlMember(Alias = "networks")]
        public Dictionary<string, Network>? Networks { get; set; }

        [YamlMember(Alias = "secrets")]
        public Dictionary<string, Secret>? Secrets { get; set; }

        [YamlMember(Alias = "volumes")]
        public Dictionary<string, Volume>? Volumes { get; set; }
    }
}
