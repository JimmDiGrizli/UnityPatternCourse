using UnityEngine;

namespace Task_3.Scripts
{
    [SelectionBase]
    public abstract class Coin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICoinPicker coinPicker) == false)
                return;

            Debug.Log("Проигрывается музыка подбора монетки");
            Debug.Log("Приогрывается анимации");

            AddCoins(coinPicker);

            Destroy(gameObject);
        }

        protected abstract void AddCoins(ICoinPicker coinPicker);
    }
}