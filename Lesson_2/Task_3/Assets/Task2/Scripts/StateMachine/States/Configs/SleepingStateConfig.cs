using System;
using UnityEngine;

namespace Task2.Scripts.StateMachine.States.Configs
{
    [Serializable]
    public class SleepingStateConfig
    {
        [SerializeField, Min(0)] private float _time;
        
        public float Time => _time;
    }
}