using DockerComposeBuilder.Builders.Base;
using DockerComposeBuilder.Model;

namespace DockerComposeBuilder.Builders
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
