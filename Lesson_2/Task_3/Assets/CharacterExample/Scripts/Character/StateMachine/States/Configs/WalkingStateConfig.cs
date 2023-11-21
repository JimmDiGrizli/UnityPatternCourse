using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [SerializeField, Range(0, 1)] private float _speedRate;

    public float SpeedRate => _speedRate;
}
