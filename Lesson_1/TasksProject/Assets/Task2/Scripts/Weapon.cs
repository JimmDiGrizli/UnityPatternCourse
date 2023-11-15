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
            _muzzle = muzzle ? muzzle : throw new InvalidOperationException(nameof(muzzle));
            _projectile = projectile ? projectile : throw new InvalidOperationException(nameof(projectile));
            _projectileShooter = projectileShooter ?? throw new InvalidOperationException(nameof(projectileShooter));
        }

        public void Shoot()
        {
            var positions = _projectileShooter.Fire(_muzzle);
            if (positions is null)
                return;

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
        }
    }
}