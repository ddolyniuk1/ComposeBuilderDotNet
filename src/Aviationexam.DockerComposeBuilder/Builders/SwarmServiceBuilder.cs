using Aviationexam.DockerComposeBuilder.Model.Services;
using System;

namespace Aviationexam.DockerComposeBuilder.Builders
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
