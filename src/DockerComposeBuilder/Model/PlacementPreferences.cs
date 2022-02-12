using DockerComposeBuilder.Model.Base;
using System;

namespace DockerComposeBuilder.Model
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
