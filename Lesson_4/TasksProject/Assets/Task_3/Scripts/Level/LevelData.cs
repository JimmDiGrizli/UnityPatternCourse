using System;
using UnityEngine;

namespace Task_3.Scripts.Level
{
    [Serializable]
    public class LevelData
    {
        [SerializeField, Range(2, 10)] private int _width;
        [SerializeField, Range(2, 10)] private int _height;
        [SerializeField, Range(1, 5)] private float _padding;

        public int Width => _width;

        public int Height => _height;

        public float Padding => _padding;
    }
}