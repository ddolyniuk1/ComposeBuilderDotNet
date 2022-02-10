using Aviationexam.DockerComposeBuilder.Builders.Base;
using Aviationexam.DockerComposeBuilder.Model;

namespace Aviationexam.DockerComposeBuilder.Builders
{
    public class NetworkBuilder : BuilderBase<NetworkBuilder, Network>
    {
        internal NetworkBuilder()
        {
        }

        public NetworkBuilder SetExternal(bool isExternal)
        {
            return WithProperty("external", isExternal);
        }
    }
}