using System.Collections.Generic;
using UnityEngine;

namespace Task2.Scripts.ShotPattern
{
    public class TripleShotPattern : IProjectileShooter
    {
        private const int AmmoPerShoot = 3;

        private int _ammo;

        public TripleShotPattern(int ammo)
        {
            _ammo = AmmoPerShoot >= ammo ? AmmoPerShoot : ammo;
        }

        public IReadOnlyCollection<Vector3> Fire(Transform muzzle)
        {
            if (WasteAmmo() == false)
                return null;

            var projectilePositions = new List<Vector3>();
            for (var i = 0; i < AmmoPerShoot; i++)
            {
                var position = muzzle.position;
                var forward = muzzle.forward;

                projectilePositions.Add(new Vector3(
                    position.x - forward.z * (1 - i),
                    position.y,
                    position.z + forward.x * (1 - i)
                ));
            }

            return projectilePositions;
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