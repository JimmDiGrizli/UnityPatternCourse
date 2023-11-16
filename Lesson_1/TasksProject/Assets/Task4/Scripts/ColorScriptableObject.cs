using UnityEngine;

namespace Task4.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Color", order = 1)]
    public class ColorScriptableObject : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _color;

        public string Name => _name;
        public Color Color => _color;
    }
}