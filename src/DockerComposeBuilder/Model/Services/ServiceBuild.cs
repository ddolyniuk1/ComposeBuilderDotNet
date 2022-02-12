using DockerComposeBuilder.Model.Infrastructure;
using DockerComposeBuilder.Model.Services.BuildArguments;
using YamlDotNet.Serialization;

namespace DockerComposeBuilder.Model.Services;

public class ServiceBuild
{
    [YamlMember(Alias = "context")]
    public string? Context { get; set; }

    [YamlMember(Alias = "dockerfile")]
    public string? Dockerfile { get; set; }

    [YamlMember(Alias = "args")]
    public IValueCollection<IBuildArgument>? Arguments { get; set; }
}
