using Aviationexam.DockerComposeBuilder.Builders;
using Aviationexam.DockerComposeBuilder.Enums;
using Aviationexam.DockerComposeBuilder.Extensions;
using Aviationexam.DockerComposeBuilder.Model;
using System;

var dbUser = "root";
var dbPass = "pass";
var dbName = "wordpress";

var network1 = Builder.MakeNetwork("my-net")
    .SetExternal(true)
    .Build();

var network2 = Builder.MakeNetwork("my-net2")
    .Build();

var secret1 = Builder.MakeSecret("secret_1")
    .WithFile("test.txt")
    .Build();

var mysql = Builder.MakeService("db")
    .WithImage("mysql:5.7")
    .WithNetworks(network1)
    .WithExposed("3306")
    .WithEnvironment(mb =>
    {
        mb.Add("MYSQL_ROOT_PASSWORD", dbPass);
        mb.Add("MYSQL_DATABASE", dbName);
        mb.Add("MYSQL_USER", dbUser);
        mb.Add("MYSQL_PASSWORD", dbPass);
    })
    .WithRestartPolicy(ERestartMode.Always)
    .WithSecrets(secret1)
    .WithSwarm()
    .WithDeploy(d => d
        .WithMode(EReplicationMode.Replicated)
        .WithReplicas(3))
    .Build();

var wordpress = Builder.MakeService("wordpress")
    .WithImage("wordpress:latest")
    .WithNetworks(network1, network2)
    .WithPortMappings(new Port
    {
        Target = 80,
        Published = 8000,
    })
    .WithEnvironment(mb =>
    {
        mb.Add("WORDPRESS_DB_HOST", $"{mysql.Name}:3306");
        mb.Add("WORDPRESS_DB_USER", dbUser);
        mb.Add("WORDPRESS_DB_PASSWORD", dbPass);
        mb.Add("WORDPRESS_DB_NAME", dbName);
    })
    .WithDependencies(mysql)
    .WithRestartPolicy(ERestartMode.UnlessStopped)
    .WithSwarm()
    .WithDeploy(d => d
        .WithMode(EReplicationMode.Global)
    )
    .WithSecrets(secret1)
    .Build();

var compose = Builder.MakeCompose()
    .WithServices(mysql, wordpress)
    .WithNetworks(network1, network2)
    .WithSecrets(secret1)
    .Build();

// serialize our object graph to yaml for writing to a docker-compose file
var result = compose.Serialize();

Console.WriteLine(result);
Console.ReadLine();
