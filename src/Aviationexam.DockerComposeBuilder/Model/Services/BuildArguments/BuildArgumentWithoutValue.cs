using Aviationexam.DockerComposeBuilder.Model.Infrastructure;

namespace Aviationexam.DockerComposeBuilder.Model.Services.BuildArguments;

public class BuildArgumentWithoutValue : IKey, IBuildArgument
{
    public string Key { get; set; } = null!;
}
