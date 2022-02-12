using System.Runtime.Serialization;

namespace DockerComposeBuilder.Enums
{
    public enum ERestartMode
    {
        [EnumMember(Value = "always")]
        Always,

        [EnumMember(Value = "no")]
        No,

        [EnumMember(Value = "on-failure")]
        OnFailure,

        [EnumMember(Value = "unless-stopped")]
        UnlessStopped
    }
}
