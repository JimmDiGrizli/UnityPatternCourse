using UnityEngine;

namespace Task_2.Image.HUD
{
    public class CoinHUDResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load($"Assets/Task_2/Textures/CoinHUD.png") as Sprite;
    }
}