using Task2.Scripts.StateMachine.States;
using Task2.Scripts.StateMachine.States.Configs;
using UnityEngine;

namespace Task2.Scripts
{
    [CreateAssetMenu(fileName = "NpcConfig", menuName = "Configs/NpcConfig")]
    public class NpcConfig : ScriptableObject
    {
        [SerializeField] private SleepingStateConfig _sleepingStateConfig;
        [SerializeField] private WorkingStateConfig _workingStateConfig;
        [SerializeField] private MovingStateConfig _movingStateConfig;

        public SleepingStateConfig SleepingStateConfig => _sleepingStateConfig;
        public WorkingStateConfig WorkingStateConfig => _workingStateConfig;
        public MovingStateConfig MovingStateConfig => _movingStateConfig;
    }
}