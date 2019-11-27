using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using ComposeBuilderDotNet.Builders;
using ComposeBuilderDotNet.Enums;
using ComposeBuilderDotNet.Extensions;

namespace ComposeBuilderDotNet.Examples.Complex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbUser = "root";
            var dbPass = "pass";
            var dbName = "wordpress"; 

            var network1 = Builder.MakeNetwork("my-net")
                .SetExternal(false)
                .Build();

            var network2 = Builder.MakeNetwork("my-net2")
                .SetExternal(false)
                .Build();

            var mysql = Builder.MakeService("db")
                .WithImage("mysql:5.7")
                .WithNetworks(network1)
                .WithExposed("3306") 
                .WithEnvironment(mb => mb
                    .WithProperty("MYSQL_ROOT_PASSWORD", dbPass)
                    .WithProperty("MYSQL_DATABASE", dbName)
                    .WithProperty("MYSQL_USER", dbUser)
                    .WithProperty("MYSQL_PASSWORD", dbPass)
                )
                .WithSwarm()
                .WithDeploy(d => d
                    .WithMode(EReplicationMode.Replicated)
                    .WithReplicas(3))
                .Build();

            var wordpress = Builder.MakeService("wordpress")
                .WithImage("wordpress:latest")
                .WithNetworks(network1, network2)
                .WithPortMapping("8000:80") 
                .WithEnvironment(mb => mb
                    .WithProperty("WORDPRESS_DB_HOST", $"{mysql.Name}:3306")
                    .WithProperty("WORDPRESS_DB_USER", dbUser)
                    .WithProperty("WORDPRESS_DB_PASSWORD", dbPass)
                    .WithProperty("WORDPRESS_DB_NAME", dbName)
                )
                .WithSwarm()
                .WithDeploy(d => d
                    .WithMode(EReplicationMode.Global) 
                )
                .Build();

            var compose = Builder.MakeCompose()
                .WithServices(mysql, wordpress)
                .WithNetworks(network1, network2)
                .Build();

            var result = compose.Serialize();
            var path = GetExecutingDirectory() + "/docker-compose.yml";

            try
            {
                var directory = AppDomain.CurrentDomain.BaseDirectory + "output";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(directory + "\\docker-compose.yml", result);
                Process.Start("explorer.exe", directory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static DirectoryInfo GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.AbsolutePath).Directory;
        }
    }
}