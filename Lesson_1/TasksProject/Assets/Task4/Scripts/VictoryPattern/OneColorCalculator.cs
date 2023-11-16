using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task4.Scripts.VictoryPattern
{
    public class OneColorCalculator : VictoryCalculator
    {
        private readonly ColorScriptableObject _winColor;
        private int _count;

        public OneColorCalculator(IReadOnlyCollection<IBall> balls) : base(balls)
        {
            _winColor = balls.First().Color;
            _count = balls.Count(ball => ball.Color == _winColor);

            Debug.Log($"Для победы нужно лопнуть все шары с цветом: {_winColor.Name}");
        }

        protected override void Interact(ColorScriptableObject color)
        {
            if (color != _winColor)
            {
                Finish(false);
            }

            if (--_count != 0)
            {
                return;
            }

            Finish(true);
        }
    }
}