using Aviationexam.DockerComposeBuilder.Builders;
using Aviationexam.DockerComposeBuilder.Extensions;
using Xunit;

namespace Aviationexam.DockerComposeBuilder.Tests;

public class ComposeBuilderTests
{
    [Fact]
    public void EmptyComposeBuilderTest()
    {
        var compose = Builder.MakeCompose()
            .Build();

        var result = compose.Serialize();

        Assert.Equal("version: \"3.7\"\n", result);
    }
}
