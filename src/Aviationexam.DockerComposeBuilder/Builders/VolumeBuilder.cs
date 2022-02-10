using Aviationexam.DockerComposeBuilder.Builders.Base;
using Aviationexam.DockerComposeBuilder.Model;

namespace Aviationexam.DockerComposeBuilder.Builders
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