using System;
using Task2.Scripts.StateMachine;
using UnityEngine;

namespace Task2.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Npc : MonoBehaviour
    {
        [SerializeField] private NpcConfig _config;
        [SerializeField] private Transform _sleepZone;
        [SerializeField] private Transform _workZone;

        private NpcStateMachine _stateMachine;

        public event Action SleepStated;
        public event Action WorkStarted;

        public NpcConfig Config => _config;
        public Transform SleepZone => _sleepZone;
        public Transform WorkZone => _workZone;

        private void Awake() => _stateMachine = new NpcStateMachine(this);

        private void Update() => _stateMachine.Update();

        public void Sleep() => SleepStated?.Invoke();

        public void Work() => WorkStarted?.Invoke();
    }
}