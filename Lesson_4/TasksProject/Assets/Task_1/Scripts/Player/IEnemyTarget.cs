using UnityEngine;

namespace Task_1.Scripts.Player
{
    public interface IEnemyTarget: IDamageable
    {
        Vector3 Position { get; }
    }
}
