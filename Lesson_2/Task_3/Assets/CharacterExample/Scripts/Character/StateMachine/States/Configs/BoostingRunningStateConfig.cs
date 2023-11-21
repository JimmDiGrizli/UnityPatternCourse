using System;
using UnityEngine;

[Serializable]
public class BoostingRunningStateConfig
{
    [SerializeField, Range(1, 2)] private float _speedRate;

    public float SpeedRate => _speedRate;
}
