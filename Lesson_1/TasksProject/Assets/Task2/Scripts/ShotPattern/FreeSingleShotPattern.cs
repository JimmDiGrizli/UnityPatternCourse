using System.Collections.Generic;
using UnityEngine;

namespace Task2.Scripts.ShotPattern
{
    public class FreeSingleShotPattern : IProjectileShooter
    {
        public bool IsCanShoot() => true;

        public IReadOnlyCollection<Vector3> Fire(Transform muzzle)
        {
            return new[] { muzzle.position };
        }
    }
}