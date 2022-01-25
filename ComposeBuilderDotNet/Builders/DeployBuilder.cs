using ComposeBuilderDotNet.Builders.Base;
using ComposeBuilderDotNet.Enums;
using ComposeBuilderDotNet.Model;
using System;
using System.Collections.Generic;

namespace ComposeBuilderDotNet.Builders
{
    public class DeployBuilder : BuilderBase<DeployBuilder, Deploy>
    {
        internal DeployBuilder()
        {
            WithName("deploy");
        }

        public DeployBuilder WithLabels(IDictionary<string, string> labels)
        {
            WorkingObject.Labels = labels;
            return this;
        }

        public DeployBuilder WithLabels(Action<MapBuilder> environmentExpression)
        {
            var mb = new MapBuilder().WithName("labels");
            environmentExpression(mb);
            return WithMap(mb.Build());
        }

        public DeployBuilder WithMode(EReplicationMode mode)
        {
            WorkingObject.Mode = mode;
            return this;
        }

        public DeployBuilder WithReplicas(int replicas)
        {
            WorkingObject.Replicas = replicas;
            return this;
        }
        public DeployBuilder WithUpdateConfig(Action<MapBuilder> updateConfig)
        {
            var mb = new MapBuilder().WithName("update_config");
            updateConfig(mb);
            return WithMap(mb.Build());
        }
        public DeployBuilder WithRestartPolicy(Action<MapBuilder> restartPolicy)
        {
            var mb = new MapBuilder().WithName("restart_policy");
            restartPolicy(mb);
            return WithMap(mb.Build());
        }
        public DeployBuilder WithPlacement(Action<MapBuilder> placement)
        {
            var mb = new MapBuilder().WithName("placement");
            placement(mb);
            return WithMap(mb.Build());
        }
        public DeployBuilder WithResources(Action<MapBuilder> resources)
        {
            var mb = new MapBuilder().WithName("resources");
            resources(mb);
            return WithMap(mb.Build());
        }
    }
}
