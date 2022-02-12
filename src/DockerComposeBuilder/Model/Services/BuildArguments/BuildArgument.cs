using DockerComposeBuilder.Model.Infrastructure;

namespace DockerComposeBuilder.Model.Services.BuildArguments;

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
