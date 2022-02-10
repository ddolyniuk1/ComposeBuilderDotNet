using System.Runtime.Serialization;

namespace Aviationexam.DockerComposeBuilder.Enums
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
