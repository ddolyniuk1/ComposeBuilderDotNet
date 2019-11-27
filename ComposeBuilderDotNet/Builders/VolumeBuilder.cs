using ComposeBuilderDotNet.Builders.Base;
using ComposeBuilderDotNet.Model;

namespace ComposeBuilderDotNet.Builders
{
    public class VolumeBuilder : BuilderBase<VolumeBuilder, Volume>
    {
        internal VolumeBuilder()
        {
        }

        public VolumeBuilder SetExternal(bool isExternal)
        {
            return WithProperty("external", isExternal);
        }
    }
}