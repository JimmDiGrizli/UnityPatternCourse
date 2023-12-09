using System;

namespace Task_2.Scripts.Images.HUD
{
    public class HUDResourceFactory : ResourceImageFactory
    {
        public override ImageResource Get(ResourceType type)
        {
            return type switch
            {
                ResourceType.Coin => new CoinHUDResourceFactory(),
                ResourceType.Energy => new EnergyHUDResourceFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }
    }
}