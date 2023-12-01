using UnityEngine;

namespace Task_2.Image.Store
{
    public class CoinStoreResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load($"Assets/Task_2/Textures/CoinStore.png") as Sprite;
        
    }
}