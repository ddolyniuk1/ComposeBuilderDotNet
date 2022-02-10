using Aviationexam.DockerComposeBuilder.Builders.Base;
using Aviationexam.DockerComposeBuilder.Model;

namespace Aviationexam.DockerComposeBuilder.Builders
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