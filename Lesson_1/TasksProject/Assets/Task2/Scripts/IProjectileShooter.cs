using System.Collections.Generic;
using UnityEngine;

namespace Task2.Scripts
{
    public interface IProjectileShooter
    {
        bool IsCanShoot();
        IReadOnlyCollection<Vector3> Fire(Transform muzzle);
    }
}