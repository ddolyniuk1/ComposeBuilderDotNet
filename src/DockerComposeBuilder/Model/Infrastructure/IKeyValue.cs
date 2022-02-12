namespace DockerComposeBuilder.Model.Infrastructure;

public interface IKeyValue : IKey
{
    string Value { get; set; }
}
