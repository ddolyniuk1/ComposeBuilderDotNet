using System;

namespace ComposeBuilderDotNet.Builders
{
    public class SwarmServiceBuilder : ServiceBuilder
    {
        public SwarmServiceBuilder WithDeploy(Action<DeployBuilder> builderExpression)
        {
            var deployBuilder = new DeployBuilder();
            builderExpression(deployBuilder);
            return WithMap(deployBuilder.Build()) as SwarmServiceBuilder;
        }
    }
}