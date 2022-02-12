using Aviationexam.DockerComposeBuilder.Builders;
using Aviationexam.DockerComposeBuilder.Extensions;
using Aviationexam.DockerComposeBuilder.Model.Services.BuildArguments;
using System.Collections.Generic;
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

        Assert.Equal(
            @"version: ""3.7""
", result
        );
    }

    [Fact]
    public void ServiceWithImageTest()
    {
        var compose = Builder.MakeCompose()
            .WithServices(Builder.MakeService("a-service")
                .WithImage("aviationexam/a-service")
                .Build()
            )
            .Build();

        var result = compose.Serialize();

        Assert.Equal(
            @"version: ""3.7""
services:
  a-service:
    image: ""aviationexam/a-service""
", result);
    }

    [Fact]
    public void ServiceWithBuildTest()
    {
        var compose = Builder.MakeCompose()
            .WithServices(Builder.MakeService("a-service")
                .WithImage("aviationexam/a-service")
                .WithBuild(x => x
                    .WithDockerfile("a.dockerfile")
                )
                .Build()
            )
            .Build();

        var result = compose.Serialize();

        Assert.Equal(
            @"version: ""3.7""
services:
  a-service:
    image: ""aviationexam/a-service""
    build:
      dockerfile: ""a.dockerfile""
", result);
    }

    [Fact]
    public void ServiceWithBuildArgumentsTest()
    {
        var compose = Builder.MakeCompose()
            .WithServices(Builder.MakeService("a-service")
                .WithImage("aviationexam/a-service")
                .WithBuild(x => x
                    .WithContext(".")
                    .WithDockerfile("a.dockerfile")
                    .WithArguments(a => a
                        .AddWithoutValue("ENV_1")
                        .Add(new KeyValuePair<string, string>("ENV_2", "value"))
                        .Add(new BuildArgument("ENV_3", "value"))
                    )
                )
                .Build()
            )
            .Build();

        var result = compose.Serialize();

        Assert.Equal(
            @"version: ""3.7""
services:
  a-service:
    image: ""aviationexam/a-service""
    build:
      context: "".""
      dockerfile: ""a.dockerfile""
      args:
      - ""ENV_1""
      - ""ENV_2=value""
      - ""ENV_3=value""
", result);
    }
}
