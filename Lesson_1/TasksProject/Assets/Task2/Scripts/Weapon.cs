using System;
using UnityEngine;

namespace Task2.Scripts
{
    public class Weapon
    {
        private readonly Transform _muzzle;
        private readonly Projectile _projectile;
        private readonly IProjectileShooter _projectileShooter;

        public Weapon(Transform muzzle, Projectile projectile, IProjectileShooter projectileShooter)
        {
            _muzzle = muzzle;
            _projectile = projectile;
            _projectileShooter = projectileShooter;
        }

        public void Shoot()
        {
            if (_projectileShooter.IsCanShoot() == false)
            {
                Debug.Log($"Не хватает патронов для выстрела.");
                return;
            }
            var positions = _projectileShooter.Fire(_muzzle);

            if (positions is null)
            {
                return;
            }

            foreach (var position in positions)
            {
                CreateBullet(position);
            }
        }

        private void CreateBullet(Vector3 position)
        {
            var projectile = GameObject.Instantiate(_projectile);
            var transform = projectile.transform;

            transform.position = position;
            transform.forward = _muzzle.forward;

            projectile.Launch();
        }
    }
}