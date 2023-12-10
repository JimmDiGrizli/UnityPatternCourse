using System;
using UnityEngine;

namespace Task_3.Scripts.Coins
{
    [SelectionBase]
    public abstract class Coin : MonoBehaviour
    {
        public event Action OnPicked;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICoinPicker coinPicker) == false)
                return;

            Debug.Log("Проигрывается музыка подбора монетки");
            Debug.Log("Приогрывается анимации");

            AddCoins(coinPicker);
            OnPicked?.Invoke();
            
            Destroy(gameObject);
        }

        protected abstract void AddCoins(ICoinPicker coinPicker);
    }
}