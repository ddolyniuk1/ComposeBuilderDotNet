using ComposeBuilderDotNet.Model;
using System;

namespace ComposeBuilderDotNet.Builders
{
    public class SwarmServiceBuilder : ServiceBuilder
    {
        public SwarmServiceBuilder WithDeploy(Action<DeployBuilder> builderExpression)
        {
            var deployBuilder = new DeployBuilder();
            builderExpression(deployBuilder);

            return WithDeploy(deployBuilder.Build());
        }

        protected SwarmServiceBuilder WithDeploy(Deploy deploy)
        {
            WorkingObject.Deploy = deploy;
            return this;
        }
    }
}
