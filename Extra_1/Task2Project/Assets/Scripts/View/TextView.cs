using TMPro;
using UnityEngine;

namespace View
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void UpdateText(int value) => _text.SetText(value.ToString());
    }
}