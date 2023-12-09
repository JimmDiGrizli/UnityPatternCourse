using UnityEngine;

namespace Task_2.Scripts.Images.HUD
{
    public class CoinHUDResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load<Sprite>("Textures/CoinHUD");
        
    }
}