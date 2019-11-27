using System;
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
            var service1 = Builder.MakeService("test")
                .WithImage("edge360/vms.ignite")
                .WithNetworks("someNetwork")
                .WithExposed("9042")
                .WithContainerName("ignite.db")
                .Build();
            var service2 = Builder.MakeService("test2")
                .WithImage("edge360/vms.apigateway")
                .WithNetworks("someNetwork")
                .WithPortMapping("5001:5001")
                .WithContainerName("test2")
                .WithEnvironment("test=true", "buildtype=dev")
                .WithMap("build", m => {
                    m.WithProperty("context", "./")
                   .WithProperty("dockerfile", "./dockerfile");
                })
                .WithSwarm()
                .WithDeploy(d => {
                    d.WithMode(EReplicationMode.Global)
                    .WithReplicas(5);
                })
                .Build();
            var network1 = Builder.MakeNetwork("someNetwork")
                .SetExternal(false)
                .Build();
            var compose = Builder.MakeCompose("3.7")
                .WithServices(service1, service2)
                .WithNetworks(network1)
                .Build();

            var result = compose.Serialize();
            var path = GetExecutingDirectory() + "/docker-compose.yml";
             
            try
            {
                var directory = AppDomain.CurrentDomain.BaseDirectory + "output";
                if(!Directory.Exists(directory))
                {   
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(directory + "\\docker-compose.yml", result);
                System.Diagnostics.Process.Start("explorer.exe", directory);
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
