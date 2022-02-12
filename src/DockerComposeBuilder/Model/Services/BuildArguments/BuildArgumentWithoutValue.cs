using DockerComposeBuilder.Model.Infrastructure;

namespace DockerComposeBuilder.Model.Services.BuildArguments;

public class BuildArgumentWithoutValue : IKey, IBuildArgument
{
    public string Key { get; set; } = null!;
}
