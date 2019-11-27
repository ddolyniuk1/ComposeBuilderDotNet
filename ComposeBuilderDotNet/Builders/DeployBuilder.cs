using ComposeBuilderDotNet.Enums;

namespace ComposeBuilderDotNet.Builders
{
    public class DeployBuilder : MapBuilder
    {
        internal DeployBuilder()
        {
            WithName("deploy");
        }

        public DeployBuilder WithMode(EReplicationMode mode)
        {
            return WithProperty("mode", mode.ToString().ToLowerInvariant()) as DeployBuilder;
        }

        public DeployBuilder WithReplicas(int replicas)
        {
            return WithProperty("replicas", replicas.ToString()) as DeployBuilder;
        }
    }
}