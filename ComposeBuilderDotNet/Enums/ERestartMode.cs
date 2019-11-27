using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComposeBuilderDotNet.Enums
{
    public enum ERestartMode
    {
        [Description("always")]
        Always,
        [Description("no")] 
        No,
        [Description("on-failure")]
        OnFailure,
        [Description("unless-stopped")]
        UnlessStopped
    }


}
