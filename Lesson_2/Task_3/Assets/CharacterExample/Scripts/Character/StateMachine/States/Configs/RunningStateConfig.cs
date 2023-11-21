using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private BoostingRunningStateConfig _boostingRunningStateConfig;

    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public BoostingRunningStateConfig BoostingRunningStateConfig => _boostingRunningStateConfig;

    public float Speed => _speed;
}
