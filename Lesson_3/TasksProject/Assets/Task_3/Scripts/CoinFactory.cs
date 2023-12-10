using System;
using Task_3.Scripts.Coins;
using UnityEngine;

namespace Task_3.Scripts
{
    [CreateAssetMenu(fileName = "CoinFactory", menuName = "Factory/CoinFactory")]
    public class CoinFactory : ScriptableObject
    {
        [SerializeField] private EmptyCoin _emptyCoinPrefab;
        [SerializeField] private StandardCoin _standardCoinPrefab;
        [SerializeField] private RandomCoin _randomCoinPrefab;

        public Coins.Coin Get(CoinType type)
        {
            return type switch
            {
                CoinType.Empty => Instantiate(_emptyCoinPrefab),
                CoinType.Standard => Instantiate(_standardCoinPrefab),
                CoinType.Random => Instantiate(_randomCoinPrefab),
                _ => throw new ArgumentException(nameof(type))
            };
        }
    }
}