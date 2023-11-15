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

        public IReadOnlyCollection<Vector3> Fire(Transform muzzle)
        {
            return WasteAmmo() ? new[] { muzzle.position } : null;
        }

        private bool WasteAmmo()
        {
            if (_ammo < AmmoPerShoot)
            {
                Debug.Log($"Не хватает {AmmoPerShoot - _ammo} патронов для выстрела.");
                return false;
            }

            _ammo -= AmmoPerShoot;
            Debug.Log($"Осталось патронов: {_ammo}.");
            return true;
        }
    }
}