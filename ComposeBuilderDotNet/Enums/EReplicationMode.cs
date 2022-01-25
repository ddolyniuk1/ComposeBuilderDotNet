using System.Runtime.Serialization;

namespace ComposeBuilderDotNet.Enums
{
    public enum EReplicationMode
    {
        [EnumMember(Value="replicated")]
        Replicated,
        [EnumMember(Value="global")]
        Global
    }
}
