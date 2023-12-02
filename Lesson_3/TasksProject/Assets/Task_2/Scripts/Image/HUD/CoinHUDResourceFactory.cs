using UnityEngine;

namespace Task_2.Scripts.Image.HUD
{
    public class CoinHUDResourceFactory : ImageResource
    {
        public override Sprite ProvideImage() => Resources.Load<Sprite>("Textures/CoinHUD");
        
    }
}