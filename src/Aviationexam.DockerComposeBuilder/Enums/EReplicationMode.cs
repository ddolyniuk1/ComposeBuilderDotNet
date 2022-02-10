using System.Runtime.Serialization;

namespace Aviationexam.DockerComposeBuilder.Enums
{
    public enum EReplicationMode
    {
        [EnumMember(Value = "replicated")]
        Replicated,

        [EnumMember(Value = "global")]
        Global,
    }
}
