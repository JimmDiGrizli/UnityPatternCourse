using System.Collections.Generic;
using Task2.Scripts.ShotPattern;
using UnityEngine;

namespace Task2.Scripts
{
    public class WeaponExample : MonoBehaviour
    {
        [SerializeField] private Transform _muzzle;
        [SerializeField] private Projectile _projectile;
        private List<Weapon> _weapons;
        private int _currentWeapon;

        private void Awake()
        {
            _weapons = new List<Weapon>(new[]
                {
                    new Weapon(_muzzle, _projectile, new SingleShotPattern(5)),
                    new Weapon(_muzzle, _projectile, new FreeSingleShotPattern()),
                    new Weapon(_muzzle, _projectile, new TripleShotPattern(36)),
                }
            );
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LastWeapon();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                NextWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Space))
                _weapons?[_currentWeapon]?.Shoot();
        }

        private void LastWeapon()
        {
            if (_weapons.Count == 0)
            {
                return;
            }

            if (_currentWeapon > 0)
            {
                _currentWeapon = _weapons.Count - 1;
            }
            else
            {
                _currentWeapon--;
            }

            Debug.Log($"Выбрали оружие {_currentWeapon}.");
        }

        private void NextWeapon()
        {
            if (_weapons.Count == 0)
            {
                return;
            }

            if (_currentWeapon == _weapons.Count)
            {
                _currentWeapon = 0;
            }
            else
            {
                _currentWeapon++;
            }

            Debug.Log($"Выбрали оружие {_currentWeapon}.");
        }
    }
}