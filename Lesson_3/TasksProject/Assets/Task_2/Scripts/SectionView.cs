using Task_2.Scripts.Images;
using UnityEngine;
using UnityEngine.UI;

namespace Task_2.Scripts
{
    public class SectionView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [field: SerializeField] public ResourceType Type { get; private set; }
        
        private void OnValidate() => _image ??= GetComponent<Image>();
        
        public void Render(ImageResource imageResource) => _image.sprite = imageResource.ProvideImage();
    }
}