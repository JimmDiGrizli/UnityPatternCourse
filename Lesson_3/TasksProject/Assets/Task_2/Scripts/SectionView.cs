using Task_2.Scripts.Image;
using UnityEngine;

namespace Task_2.Scripts
{
    public class SectionView : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Image _image;

        [field: SerializeField] public ResourceType Type { get; private set; }
        
        private void OnValidate() => _image ??= GetComponent<UnityEngine.UI.Image>();

        public void Render(ImageResource imageResource) => _image.sprite = imageResource.ProvideImage();
    }
}