using UnityEngine;

namespace Task_2.Image.Store
{
    public class EnergyStoreResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load($"Assets/Task_2/Textures/EnergyStore.png") as Sprite;
    }
}