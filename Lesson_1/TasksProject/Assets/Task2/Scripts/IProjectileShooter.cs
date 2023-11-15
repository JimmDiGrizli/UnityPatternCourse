using System.Collections.Generic;
using UnityEngine;

namespace Task2.Scripts
{
    public interface IProjectileShooter
    {
        IReadOnlyCollection<Vector3> Fire(Transform muzzle);
    }
}