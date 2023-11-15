using System.Collections.Generic;
using UnityEngine;

namespace Task2.Scripts.ShotPattern
{
    public class FreeSingleShotPattern : IProjectileShooter
    {
        public IReadOnlyCollection<Vector3> Fire(Transform muzzle)
        {
            return new[] { muzzle.position };
        }
    }
}