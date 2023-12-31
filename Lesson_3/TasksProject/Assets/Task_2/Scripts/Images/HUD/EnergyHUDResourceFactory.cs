using UnityEngine;

namespace Task_2.Scripts.Images.HUD
{
    public class EnergyHUDResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load<Sprite>("Textures/EnergyHUD");
    }
}