using ComposeBuilderDotNet.Model.Base;
using System;

namespace ComposeBuilderDotNet.Model
{
    [Serializable]
    public class PlacementPreferences : ObjectBase
    {
        public string Spread
        {
            get => GetProperty<string>("spread");
            set => SetProperty("spread", value);
        }
    }
}
