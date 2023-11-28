using TMPro;
using UnityEngine;

namespace View
{
    public class PlayerPropertyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        public void UpdateText(int value)
        {
            Show();
            _text.SetText(value.ToString());
        }
    }
}