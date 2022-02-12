using DockerComposeBuilder.Model.Services.BuildArguments;

namespace DockerComposeBuilder.Builders.Services;

public class BuildArgumentBuilder : GenericKeyValueBuilder<BuildArgumentBuilder, IBuildArgument, BuildArgumentWithoutValue, BuildArgument>
{
}
