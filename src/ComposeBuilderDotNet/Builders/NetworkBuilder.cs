using ComposeBuilderDotNet.Builders.Base;
using ComposeBuilderDotNet.Model;

namespace ComposeBuilderDotNet.Builders
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