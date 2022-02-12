using DockerComposeBuilder.Builders.Base;
using DockerComposeBuilder.Model;

namespace DockerComposeBuilder.Builders
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
