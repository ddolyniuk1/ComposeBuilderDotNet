using DockerComposeBuilder.Builders.Base;
using DockerComposeBuilder.Model;

namespace DockerComposeBuilder.Builders
{
    public class SecretBuilder : BuilderBase<SecretBuilder, Secret>
    {
        internal SecretBuilder()
        {
        }

        public SecretBuilder WithFile(string file)
        {
            return WithProperty("file", file);
        }

        public SecretBuilder SetExternal(bool isExternal)
        {
            return WithProperty("external", isExternal);
        }
    }
}
