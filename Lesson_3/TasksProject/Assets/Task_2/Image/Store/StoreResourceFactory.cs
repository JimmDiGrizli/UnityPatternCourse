using System;

namespace Task_2.Image.Store
{
    public class StoreResourceFactory : ResourceImageFactory
    {
        public override ImageResource Get(ResourceType type)
        {
            return type switch
            {
                ResourceType.Coin => new CoinStoreResourceFactory(),
                ResourceType.Energy => new EnergyStoreResourceFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }
    }
}