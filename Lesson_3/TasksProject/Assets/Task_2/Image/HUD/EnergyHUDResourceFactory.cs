using UnityEngine;

namespace Task_2.Image.HUD
{
    public class EnergyHUDResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load($"Assets/Task_2/Textures/EnergyHUD.png") as Sprite;
    }
}