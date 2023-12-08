using UnityEngine;

namespace Task_3.Scripts.Balls
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BallColor", order = 1)]
    public class BallColor : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _color;

        public string Name => _name;
        public Color Color => _color;
    }
}