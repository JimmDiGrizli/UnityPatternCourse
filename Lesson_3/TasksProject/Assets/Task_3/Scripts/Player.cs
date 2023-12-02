using System;
using UnityEngine;

namespace Task_3.Scripts
{
    [SelectionBase]
    public class Player : MonoBehaviour, ICoinPicker
    {
        public int Coins { get; private set; }

        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Coins += value;
            Debug.Log(Coins);
        }
    }
}
