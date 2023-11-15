using System.Collections.Generic;
using UnityEngine;

namespace Task2.Scripts.ShotPattern
{
    public class SingleShotPattern : IProjectileShooter
    {
        private const int AmmoPerShoot = 1;

        private int _ammo;

        public SingleShotPattern(int ammo)
        {
            _ammo = AmmoPerShoot >= ammo ? AmmoPerShoot : ammo;
        }

        public bool IsCanShoot() => _ammo > AmmoPerShoot;

        public IReadOnlyCollection<Vector3> Fire(Transform muzzle)
        {
            return WasteAmmo() ? new[] { muzzle.position } : null;
        }

        private bool WasteAmmo()
        {
            if (IsCanShoot() == false)
            {
                return false;
            }

            _ammo -= AmmoPerShoot;
            return true;
        }
    }
}