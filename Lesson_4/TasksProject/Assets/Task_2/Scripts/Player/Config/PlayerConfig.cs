using UnityEngine;

namespace Task_2.Scripts.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField, Range(1, 100)] private int _healthPoint = 5;
        [SerializeField, Range(1, 25)] private int _level = 1;

        public int HealthPoint => _healthPoint;
        public int Level => _level;
    }
}