using Aviationexam.DockerComposeBuilder.Model.Infrastructure;

namespace Aviationexam.DockerComposeBuilder.Model.Services.BuildArguments;

public class BuildArgument : IKeyValue, IBuildArgument
{
    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public BuildArgument()
    {
    }

    public BuildArgument(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
