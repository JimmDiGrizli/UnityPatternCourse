using System.Collections.Generic;
using UnityEngine;

namespace Task4.Scripts.VictoryPattern
{
    public class AllBallsCalculator : VictoryCalculator
    {
        private int _count;

        public AllBallsCalculator(IReadOnlyCollection<IBall> balls) : base(balls)
        {
            _count = balls.Count;
            Debug.Log($"Для победы нужно лопнуть все {_count} шары.");
        }

        protected override void Interact(ColorScriptableObject color)
        {
            if (--_count != 0)
            {
                return;
            }

            Finish(true);
        }
    }
}