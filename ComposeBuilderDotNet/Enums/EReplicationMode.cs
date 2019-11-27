using System.ComponentModel;

namespace ComposeBuilderDotNet.Enums
{
    public enum EReplicationMode
    {
        [Description("replicated")]
        Replicated,
        [Description("global")]
        Global
    }
}