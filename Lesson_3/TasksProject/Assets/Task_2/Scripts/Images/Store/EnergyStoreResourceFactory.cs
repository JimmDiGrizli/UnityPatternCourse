using UnityEngine;

namespace Task_2.Scripts.Images.Store
{
    public class EnergyStoreResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load<Sprite>("Textures/EnergyStore");
    }
}