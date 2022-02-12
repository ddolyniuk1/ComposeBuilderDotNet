using DockerComposeBuilder.Enums;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace DockerComposeBuilder.Model.Services
{
    [Serializable]
    public class Deploy
    {
        [YamlMember(Alias = "labels")]
        public IDictionary<string, string>? Labels { get; set; }

        [YamlMember(Alias = "mode")]
        public EReplicationMode? Mode { get; set; }

        [YamlMember(Alias = "replicas")]
        public int? Replicas { get; set; }

        [YamlMember(Alias = "update_config")]
        public Map? UpdateConfig { get; set; }

        [YamlMember(Alias = "restart_policy")]
        public Map? RestartPolicy { get; set; }

        [YamlMember(Alias = "placement")]
        public Map? Placement { get; set; }

        [YamlMember(Alias = "resources")]
        public Map? Resources { get; set; }
    }
}
